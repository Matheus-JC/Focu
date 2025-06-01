using Focu.Api.Data;
using Focu.Core.Enums;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Requests.Stripe;
using Focu.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class OrderHandler(AppDbContext context, IStripeHandler stripeHandler) : IOrderHandler
{
    public async Task<Response<Order?>> CancelAsync(CancelOrderRequest request)
    {
        var order = await context
            .Orders
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

        if (order is null)
            return new Response<Order?>(null, StatusCodes.Status404NotFound, "Order not found");

        switch (order.Status)
        {
            case OrderStatus.Canceled:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "Order is already canceled!");

            case OrderStatus.Paid:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "A paid order cannot be canceled!");

            case OrderStatus.Refunded:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "A refunded order cannot be canceled");

            case OrderStatus.WaitingPayment:
                break;

            default:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "Invalid order status!");
        }

        order.Status = OrderStatus.Canceled;
        order.UpdatedAt = DateTime.Now;

        context.Orders.Update(order);
        await context.SaveChangesAsync();

        return new Response<Order?>(order, StatusCodes.Status200OK, $"Order {order.Number} updated!");
    }

    public async Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
    {
        var product = await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.ProductId && x.IsActive == true);

        if (product is null)
            return new Response<Order?>(null, StatusCodes.Status404NotFound, "Product not found or inactive");

        context.Attach(product);

        Voucher? voucher = null;
        if (request.VoucherId is not null)
        {
            voucher = await context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.VoucherId && x.IsActive == true);

            if (voucher is null)
                return new Response<Order?>(null, StatusCodes.Status404NotFound, "Voucher not found or inactive");

            if (voucher.IsActive == false)
                return new Response<Order?>(null, StatusCodes.Status404NotFound, "This voucher has already been used");

            voucher.IsActive = false;
            context.Vouchers.Update(voucher);
        }

        var order = new Order
        {
            UserId = request.UserId,
            Product = product,
            ProductId = request.ProductId,
            Voucher = voucher,
            VoucherId = request.VoucherId
        };

        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();

        return new Response<Order?>(order, StatusCodes.Status201Created, $"Order {order.Number} created successfully!");
    }

    public async Task<Response<Order?>> PayAsync(PayOrderRequest request)
    {
        var order = await context
            .Orders
            .Include(x => x.Product)
            .Include(x => x.Voucher)
            .FirstOrDefaultAsync(x => x.Number == request.OrderNumber && x.UserId == request.UserId);

        if (order is null)
            return new Response<Order?>(null, StatusCodes.Status404NotFound, $"Order {request.OrderNumber} not found");

        switch (order.Status)
        {
            case OrderStatus.Canceled:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "The order is canceled!");

            case OrderStatus.Paid:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "The order is already paid");

            case OrderStatus.Refunded:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "A refunded order cannot be paid");

            case OrderStatus.WaitingPayment:
                break;

            default:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "Invalid order status");
        }

        var getTransactionByOrderNumberRequest = new GetTransactionByOrderNumberRequest
        {
            Number = order.Number,
        };
        var result = await stripeHandler.GetTransactionsByOrderNumberAsync(getTransactionByOrderNumberRequest);

        if (result.IsSuccess == false || result.Data is null)
            return new Response<Order?>(null, StatusCodes.Status500InternalServerError, "Unable to locate the payment for your order!");

        if (result.Data.Any(item => item.Refunded))
            return new Response<Order?>(null, StatusCodes.Status500InternalServerError, "This order has been refunded and cannot be paid!");

        if (!result.Data.Any(item => item.Paid))
            return new Response<Order?>(null, StatusCodes.Status500InternalServerError, "This order has not been paid yet!");

        request.ExternalReference = result.Data[0].Id;

        order.Status = OrderStatus.Paid;
        order.ExternalReference = request.ExternalReference;
        order.UpdatedAt = DateTime.Now;

        context.Orders.Update(order);
        await context.SaveChangesAsync();

        return new Response<Order?>(order, StatusCodes.Status200OK, $"Order {order.Number} paid successfully!");
    }

    public async Task<Response<Order?>> RefundAsync(RefundOrderRequest request)
    {
        var order = await context
            .Orders
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

        if (order is null)
            return new Response<Order?>(null, StatusCodes.Status404NotFound, "Order not found");

        switch (order.Status)
        {
            case OrderStatus.Canceled:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "The order is canceled!");

            case OrderStatus.WaitingPayment:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "The order has not been paid yet");

            case OrderStatus.Refunded:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "The order has already been refunded");

            case OrderStatus.Paid:
                break;

            default:
                return new Response<Order?>(order, StatusCodes.Status400BadRequest, "Invalid order status");
        }

        order.Status = OrderStatus.Refunded;
        order.UpdatedAt = DateTime.Now;

        context.Orders.Update(order);
        await context.SaveChangesAsync();

        return new Response<Order?>(order, StatusCodes.Status200OK, $"Order {order.Number} refunded successfully!");
    }

    public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
    {
        var query = context
            .Orders
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Voucher)
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.CreatedAt);

        var orders = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<List<Order>?>(
            orders,
            count,
            request.PageNumber,
            request.PageSize);
    }

    public async Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
    {
        var order = await context
            .Orders
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Voucher)
            .FirstOrDefaultAsync(x => x.Number == request.Number && x.UserId == request.UserId);

        return order is null
            ? new Response<Order?>(null, StatusCodes.Status404NotFound, "Order not found")
            : new Response<Order?>(order);
    }
}

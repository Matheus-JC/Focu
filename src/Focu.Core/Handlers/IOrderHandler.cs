using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Responses;

namespace Focu.Core.Handlers;

public interface IOrderHandler
{
    Task<Response<Order?>> CancelAsync(CancelOrderRequest request);
    Task<Response<Order?>> CreateAsync(CreateOrderRequest request);
    Task<Response<Order?>> PayAsync(PayOrderRequest request);
    Task<Response<Order?>> RefundAsync(RefundOrderRequest request);
    Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request);
    Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request);
}
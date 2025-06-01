using Focu.Core.Handlers;
using Focu.Core.Requests.Stripe;
using Focu.Core.Responses;
using Focu.Core.Responses.Stripe;
using Stripe;
using Stripe.Checkout;
using Configuration = Focu.Core.Common.Configuration;

namespace Focu.Api.Handlers;

public class StripeHandler : IStripeHandler
{
    public async Task<Response<string?>> CreateSessionAsync(CreateSessionRequest request)
    {
        var options = new SessionCreateOptions
        {
            CustomerEmail = request.UserId.ToString(),
            PaymentIntentData = new SessionPaymentIntentDataOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "order", request.OrderNumber }
                }
            },
            PaymentMethodTypes = ["card"],
            LineItems =
            [
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "BRL",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.ProductTitle,
                            Description = request.ProductDescription
                        },
                        UnitAmount = request.OrderTotal,
                    },
                    Quantity = 1
                }
            ],
            Mode = "payment",
            SuccessUrl = $"{Configuration.FrontendUrl}/orders/{request.OrderNumber}/confirm",
            CancelUrl = $"{Configuration.FrontendUrl}/orders/{request.OrderNumber}/cancel",
        };

        var service = new Stripe.Checkout.SessionService();
        var session = await service.CreateAsync(options);

        return new Response<string?>(session.Id, StatusCodes.Status201Created, "Payment session created successfully");
    }

    public async Task<Response<List<StripeTransactionResponse>>> GetTransactionsByOrderNumberAsync(
        GetTransactionByOrderNumberRequest request)
    {
        var options = new ChargeSearchOptions
        {
            Query = $"metadata['order']:'{request.Number}'",
        };
        var service = new ChargeService();
        var result = await service.SearchAsync(options);

        if (result.Data.Count == 0)
            return new Response<List<StripeTransactionResponse>>(null, StatusCodes.Status404NotFound, "Transaction not found");

        var data = result.Data.Select(item => new StripeTransactionResponse
        {
            Id = item.Id,
            Email = item.BillingDetails.Email,
            Amount = item.Amount,
            AmountCaptured = item.AmountCaptured,
            Status = item.Status,
            Paid = item.Paid,
            Refunded = item.Refunded,
        }).ToList();

        return new Response<List<StripeTransactionResponse>>(data);
    }
}


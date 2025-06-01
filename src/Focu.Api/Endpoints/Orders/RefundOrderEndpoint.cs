using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Orders;

public class RefundOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id:guid}/refund", HandleAsync)
            .WithName("Orders: Refund an order")
            .WithSummary("Refund an order")
            .WithDescription("Refund an order")
            .WithOrder(4)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        Guid id,
        ClaimsPrincipal user)
    {
        var request = new RefundOrderRequest()
        {
            Id = id,
            UserId = user.Identity.GetUserId()
        };

        var result = await handler.RefundAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
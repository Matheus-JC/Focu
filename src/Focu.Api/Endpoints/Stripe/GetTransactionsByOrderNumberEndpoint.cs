using System.Security.Claims;
using Azure;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Handlers;
using Focu.Core.Requests.Stripe;

namespace Focu.Api.Endpoints.Stripe;

public class GetTransactionsByOrderNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}/transactions", HandleAsync)
            .Produces<Response<dynamic>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IStripeHandler handler,
        string number)
    {
        var request = new GetTransactionByOrderNumberRequest
        {
            UserId = user.Identity.GetUserId(),
            Number = number
        };

        var result = await handler.GetTransactionsByOrderNumberAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
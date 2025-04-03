using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Transaction;

public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id:guid}", HandleAsync)
            .WithName("Transactions: Delete")
            .WithSummary("Removes a transaction")
            .WithOrder(5)
            .Produces<Response<Core.Models.Transaction?>>()
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        Guid id)
    {
        var request = new DeleteTransactionRequest
        {
            Id = id,
            UserId = user.Identity.GetUserId()
        };
        
        var result = await handler.DeleteAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
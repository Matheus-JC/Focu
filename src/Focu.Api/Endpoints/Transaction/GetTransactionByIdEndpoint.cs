using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Transaction;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:guid}", HandleAsync)
            .WithName("Transactions: Get by Id")
            .WithSummary("Returns a transaction")
            .WithOrder(2)
            .Produces<Response<Core.Models.Transaction?>>()
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, 
        ITransactionHandler handler, 
        Guid id)
    {
        var request = new GetTransactionByIdRequest
        {
            Id = id,
            UserId = user.Identity.GetUserId()
        };
        
        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Transaction;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:guid}", HandleAsync)
            .WithName("Transactions: Update")
            .WithSummary("Updates a transaction")
            .WithOrder(4)
            .Produces<Response<Core.Models.Transaction?>>()
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status400BadRequest)            
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, 
        UpdateTransactionRequest request, 
        ITransactionHandler handler, 
        Guid id)
    {
        request.Id = id;
        request.UserId = user.Identity.GetUserId();
        
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToValidationProblem();
    }
}
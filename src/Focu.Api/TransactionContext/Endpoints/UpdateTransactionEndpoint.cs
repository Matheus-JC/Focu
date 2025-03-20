using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.TransactionDomain;
using Focu.Core.TransactionDomain.Requests;

namespace Focu.Api.TransactionContext.Endpoints;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:guid}", HandleAsync)
            .WithName("Transactions: Update")
            .WithSummary("Updates a transaction")
            .WithOrder(4)
            .Produces<Response<Transaction?>>()
            .Produces<Response<Transaction?>>(StatusCodes.Status400BadRequest)            
            .Produces<Response<Transaction?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(Guid id, UpdateTransactionRequest request, ITransactionHandler handler)
    {
        request.Id = id;
        request.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToValidationProblem();
    }
}
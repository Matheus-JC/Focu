using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.TransactionDomain;
using Focu.Core.TransactionDomain.Requests;

namespace Focu.Api.TransactionContext.Endpoints;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
            .WithName("Transactions: Create")
            .WithSummary("Creates a new transaction")
            .WithOrder(3)
            .Produces<Response<Transaction?>>(StatusCodes.Status201Created)
            .Produces<Response<Transaction?>>(StatusCodes.Status400BadRequest);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, 
        CreateTransactionRequest request, 
        ITransactionHandler handler)
    {
        request.UserId = user.Identity.GetUserId();
        
        var result = await handler.CreateAsync(request);

        return result.IsSuccess 
            ? Results.Created($"/{result.Data?.Id}", result)
            : result.ToValidationProblem();
    }
}
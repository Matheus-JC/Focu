using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Handlers;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Transaction;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
            .WithName("Transactions: Create")
            .WithSummary("Creates a new transaction")
            .WithOrder(3)
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status201Created)
            .Produces<Response<Core.Models.Transaction?>>(StatusCodes.Status400BadRequest);

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
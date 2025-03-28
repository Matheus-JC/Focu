﻿using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.TransactionDomain;
using Focu.Core.TransactionDomain.Requests;

namespace Focu.Api.TransactionContext.Endpoints;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:guid}", HandleAsync)
            .WithName("Transactions: Get by Id")
            .WithSummary("Returns a transaction")
            .WithOrder(2)
            .Produces<Response<Transaction?>>()
            .Produces<Response<Transaction?>>(StatusCodes.Status404NotFound);

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
using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Transaction;
using Focu.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Focu.Api.Endpoints.Transaction;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", HandleAsync)
            .WithName("Transactions: Get All")
            .WithSummary("Returns all user transactions by period")
            .WithOrder(1)
            .Produces<PagedResponse<List<Core.Models.Transaction>>>();
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler, 
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize
    )
    {
        var request = new GetTransactionsByPeriodRequest
        {
            UserId = user.Identity.GetUserId(),
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };
        
        var result = await handler.GetByPeriodAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
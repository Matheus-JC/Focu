using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.TransactionDomain;
using Focu.Core.TransactionDomain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Focu.Api.TransactionContext.Endpoints;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", HandleAsync)
            .WithName("Transactions: Get All")
            .WithSummary("Returns all user transactions by period")
            .WithOrder(1)
            .Produces<PagedResponse<List<Transaction>>>();
    
    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler, 
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize
    )
    {
        var request = new GetTransactionsByPeriodRequest
        {
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };
        
        var result = await handler.GetByPeriodAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
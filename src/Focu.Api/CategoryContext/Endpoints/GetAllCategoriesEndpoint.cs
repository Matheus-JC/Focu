using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.CategoryDomain;
using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Focu.Api.CategoryContext.Endpoints;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Returns all user categories")
            .WithOrder(1)
            .Produces<PagedResponse<List<Category>>>();
    
    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler, 
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize
    )
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
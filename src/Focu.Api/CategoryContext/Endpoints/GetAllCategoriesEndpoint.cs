using System.Security.Claims;
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
            .RequireAuthorization()
            .WithOrder(1)
            .Produces<PagedResponse<List<Category>>>();
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler, 
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize
    )
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity.GetUserId(),
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
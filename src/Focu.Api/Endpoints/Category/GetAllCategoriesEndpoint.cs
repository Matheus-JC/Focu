using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Focu.Api.Endpoints.Category;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Returns all user categories")
            .RequireAuthorization()
            .WithOrder(1)
            .Produces<PagedResponse<List<Core.Models.Category>>>();
    
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
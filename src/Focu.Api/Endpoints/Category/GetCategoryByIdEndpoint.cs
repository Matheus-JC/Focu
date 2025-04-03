using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Category;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:guid}", HandleAsync)
            .WithName("Categories: Get by Id")
            .WithSummary("Returns a category")
            .WithOrder(2)
            .Produces<Response<Core.Models.Category?>>()
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, 
        ICategoryHandler handler,
        Guid id)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = user.Identity.GetUserId()
        };
        
        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
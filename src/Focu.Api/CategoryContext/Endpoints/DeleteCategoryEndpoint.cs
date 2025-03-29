using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.CategoryDomain;
using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;

namespace Focu.Api.CategoryContext.Endpoints;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id:guid}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Removes a category")
            .WithOrder(5)
            .Produces<Response<Category?>>()
            .Produces<Response<Category?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        Guid id)
    {
        var request = new DeleteCategoryRequest
        {
            Id = id,
            UserId = user.Identity.GetUserId()
        };
        
        var result = await handler.DeleteAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
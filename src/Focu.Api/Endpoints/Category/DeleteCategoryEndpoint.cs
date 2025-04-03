using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Category;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id:guid}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Removes a category")
            .WithOrder(5)
            .Produces<Response<Core.Models.Category?>>()
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status404NotFound);

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
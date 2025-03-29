using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.CategoryDomain;
using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;

namespace Focu.Api.CategoryContext.Endpoints;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Creates a new category")
            .WithOrder(3)
            .Produces<Response<Category?>>(StatusCodes.Status201Created)
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest);

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        CreateCategoryRequest request, 
        ICategoryHandler handler)
    {
        request.UserId = user.Identity.GetUserId();
        
        var result = await handler.CreateAsync(request);

        return result.IsSuccess 
            ? Results.Created($"/{result.Data?.Id}", result)
            : result.ToValidationProblem();
    }
}
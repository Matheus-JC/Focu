using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Category;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Creates a new category")
            .WithOrder(3)
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status201Created)
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status400BadRequest);

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
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

    private static async Task<IResult> HandleAsync(CreateCategoryRequest request, ICategoryHandler handler)
    {
        request.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        
        var result = await handler.CreateAsync(request);

        return result.IsSuccess 
            ? Results.Created($"/{result.Data?.Id}", result)
            : result.ToValidationProblem();
    }
}
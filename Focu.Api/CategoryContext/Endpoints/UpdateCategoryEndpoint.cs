using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.CategoryDomain;
using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;

namespace Focu.Api.CategoryContext.Endpoints;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:guid}", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Updates a category")
            .WithOrder(4)
            .Produces<Response<Category?>>()
            .Produces<Response<Category?>>(StatusCodes.Status400BadRequest)            
            .Produces<Response<Category?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(Guid id, UpdateCategoryRequest request, ICategoryHandler handler)
    {
        request.Id = id;
        request.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToValidationProblem();
    }
}
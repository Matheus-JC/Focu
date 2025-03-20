using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.CategoryDomain;
using Focu.Core.CategoryDomain.Requests;
using Focu.Core.Common;

namespace Focu.Api.CategoryContext.Endpoints;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:guid}", HandleAsync)
            .WithName("Categories: Get by Id")
            .WithSummary("Returns a category")
            .WithOrder(2)
            .Produces<Response<Category?>>()
            .Produces<Response<Category?>>(StatusCodes.Status404NotFound);

    private static async Task<IResult> HandleAsync(Guid id, ICategoryHandler handler)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
        };
        
        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToProblem();
    }
}
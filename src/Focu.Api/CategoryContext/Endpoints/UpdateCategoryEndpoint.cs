using System.Security.Claims;
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

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user, 
        UpdateCategoryRequest request, 
        ICategoryHandler handler, 
        Guid id)
    {
        request.Id = id;
        request.UserId = user.Identity.GetUserId();
        
        var result = await handler.UpdateAsync(request);

        return result.IsSuccess ? Results.Ok(result) : result.ToValidationProblem();
    }
}
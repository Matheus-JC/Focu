using System.Security.Claims;
using Focu.Api.Common;
using Focu.Api.Extensions;
using Focu.Core.Common;
using Focu.Core.Handlers;
using Focu.Core.Requests.Category;
using Focu.Core.Responses;

namespace Focu.Api.Endpoints.Category;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:guid}", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Updates a category")
            .WithOrder(4)
            .Produces<Response<Core.Models.Category?>>()
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status400BadRequest)            
            .Produces<Response<Core.Models.Category?>>(StatusCodes.Status404NotFound);

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
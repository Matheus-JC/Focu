using Azure;
using Focu.Api.Common;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Orders;

namespace Focu.Api.Endpoints.Orders;

public class GetProductBySlugEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{slug}", HandleAsync)
            .WithName("Products: Get By Slug")
            .WithSummary("Get a product by its slug")
            .WithDescription("Retrieve a single product using its unique slug identifier")
            .WithOrder(4)
            .Produces<Response<Product?>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        string slug)
    {
        var request = new GetProductBySlugRequest
        {
            Slug = slug
        };

        var result = await handler.GetBySlugAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
using Focu.Api.CategoryContext.Endpoints;
using Focu.Api.TransactionContext.Endpoints;
using Focu.Core.TransactionDomain.Requests;

namespace Focu.Api.Common;

public static class EndpointMapper
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        MapCategoryEndpoints(endpoints);
        MapTransactionEndpoints(endpoints);
    }

    private static void MapCategoryEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("vi/categories")
            .WithTags("Categories")
            .MapEndpoint<GetAllCategoriesEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>();
    }

    private static void MapTransactionEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("vi/transactions")
            .WithTags("Transactions")
            .MapEndpoint<GetTransactionsByPeriodEndpoint>()
            .MapEndpoint<GetTransactionByIdEndpoint>()
            .MapEndpoint<CreateTransactionEndpoint>()
            .MapEndpoint<UpdateTransactionEndpoint>()
            .MapEndpoint<DeleteTransactionEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder route)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(route);
        return route;
    }
}
using Focu.Api.Data;
using Focu.Api.Endpoints.Category;
using Focu.Api.Endpoints.Identity;
using Focu.Api.Endpoints.Orders;
using Focu.Api.Endpoints.Reports;
using Focu.Api.Endpoints.Stripe;
using Focu.Api.Endpoints.Transaction;
using Focu.Core.Models.Account;

namespace Focu.Api.Common;

public static class EndpointMapper
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        MapHealthCheckEndpoints(endpoints);
        MapCategoryEndpoints(endpoints);
        MapTransactionEndpoints(endpoints);
        MapIdentityEndpoints(endpoints);
        MapOrderEndpoints(endpoints);
        MapStripeEndpoints(endpoints);
        MapReportEndpoints(endpoints);
    }

    private static void MapCategoryEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .RequireAuthorization()
            .MapEndpoint<GetAllCategoriesEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>();
    }

    private static void MapTransactionEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("v1/transactions")
            .WithTags("Transactions")
            .RequireAuthorization()
            .MapEndpoint<GetTransactionsByPeriodEndpoint>()
            .MapEndpoint<GetTransactionByIdEndpoint>()
            .MapEndpoint<CreateTransactionEndpoint>()
            .MapEndpoint<UpdateTransactionEndpoint>()
            .MapEndpoint<DeleteTransactionEndpoint>();
    }
    
    private static void MapIdentityEndpoints(IEndpointRouteBuilder endpoints)
    {
        var identityGroup = endpoints.MapGroup("v1/identity")
            .WithTags("Identity");
        
        // Default Identity endpoints
        identityGroup.MapIdentityApi<ApplicationUser>();

        // Custom Identity endpoints
        identityGroup
            .MapEndpoint<GetRolesEndpoint>()
            .MapEndpoint<LogoutEndpoint>();
    }
    
    private static void MapHealthCheckEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("/")
            .WithTags("Health")
            .MapGet("/", () => new { message = "OK" });
    }

    private static void MapOrderEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("v1/orders")
            .WithTags("Orders")
            .RequireAuthorization()
            .MapEndpoint<GetAllOrdersEndpoint>()
            .MapEndpoint<GetOrderByNumberEndpoint>()
            .MapEndpoint<CreateOrderEndpoint>()
            .MapEndpoint<CancelOrderEndpoint>()
            .MapEndpoint<PayOrderEndpoint>()
            .MapEndpoint<RefundOrderEndpoint>();
    }

    private static void MapStripeEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("v1/payments/stripe")
            .WithTags("Payments - Stripe")
            .RequireAuthorization()
            .MapEndpoint<CreateSessionEndpoint>()
            .MapEndpoint<GetTransactionsByOrderNumberEndpoint>();
    }

    private static void MapReportEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("/v1/reports")
            .WithTags("Reports")
            .RequireAuthorization()
            .MapEndpoint<GetIncomesAndExpensesEndpoint>()
            .MapEndpoint<GetIncomesByCategoryEndpoint>()
            .MapEndpoint<GetExpensesByCategoryEndpoint>()
            .MapEndpoint<GetFinancialSummaryEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder route)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(route);
        return route;
    }
}

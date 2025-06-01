using Focu.Api.Handlers;
using Focu.Core.Handlers;

namespace Focu.Api.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryHandler, CategoryHandler>();
        services.AddScoped<ITransactionHandler, TransactionHandler>();
        services.AddScoped<IProductHandler, ProductHandler>();
        services.AddScoped<IOrderHandler, OrderHandler>();
        services.AddScoped<IVoucherHandler, VoucherHandler>();
        services.AddScoped<IReportHandler, ReportHandler>();
        services.AddScoped<IStripeHandler, StripeHandler>();

        return services;
    }
}
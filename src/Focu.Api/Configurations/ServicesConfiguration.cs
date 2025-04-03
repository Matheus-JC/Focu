using Focu.Api.Handlers;
using Focu.Core.Handlers;

namespace Focu.Api.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryHandler, CategoryHandler>();
        services.AddTransient<ITransactionHandler, TransactionHandler>();

        return services;
    }
}
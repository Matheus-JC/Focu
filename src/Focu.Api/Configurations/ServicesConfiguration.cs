using Focu.Api.CategoryContext;
using Focu.Api.TransactionContext;
using Focu.Core.CategoryDomain;
using Focu.Core.TransactionDomain;

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
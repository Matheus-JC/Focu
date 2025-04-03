using Focu.Api.Data;
using Focu.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Configurations;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(Configuration.ConnectionString);
        });

        return services;
    }
}
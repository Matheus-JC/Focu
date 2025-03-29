using Focu.Core.Common;

namespace Focu.Api.Configurations;

public static class ApiConfiguration
{    
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        Configuration.ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.FrontendUrl = configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        Configuration.BackendUrl = configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        
        return services;
    }
    
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
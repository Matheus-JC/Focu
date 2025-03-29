using Focu.Core.Common;

namespace Focu.Api.Configurations;

public static class CorsConfiguration
{
    public const string CorsPolicyName = "wasm";

    public static IServiceCollection AddCrossOrigin(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, builder =>
            {
                builder
                    .WithOrigins(Configuration.FrontendUrl, Configuration.BackendUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        
        return services;
    }
}
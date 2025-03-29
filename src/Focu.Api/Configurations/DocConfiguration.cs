namespace Focu.Api.Configurations;

public static class DocConfiguration
{
    public static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(x => 
        {
            x.CustomSchemaIds(n => n.FullName);
        });
        
        return services;
    }
}
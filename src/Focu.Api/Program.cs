using Focu.Api;
using Focu.Api.Common;
using Focu.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiConfig(builder.Configuration)
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails()
    .AddDatabaseConfig()
    .AddIdentity()
    .AddDocumentation()
    .AddSecurity()
    .AddCrossOrigin()
    .AddServices();

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors(CorsConfiguration.CorsPolicyName);
app.UseSecurity();

if(app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.MapEndpoints();

app.Run();
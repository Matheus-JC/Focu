using Focu.Core.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Focu.Web;
using Focu.Web.Handlers;
using Focu.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

WebConfiguration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider) x.GetRequiredService<AuthenticationStateProvider>()); 

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(WebConfiguration.HttpClientName, options => 
    {
        options.BaseAddress = new Uri(WebConfiguration.BackendUrl);
    })
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<IAccountHandler, AccountHandler>();

await builder.Build().RunAsync();

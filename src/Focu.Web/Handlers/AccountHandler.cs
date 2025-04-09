using System.Net.Http.Json;
using System.Text;
using Focu.Core.Handlers;
using Focu.Core.Requests.Account;
using Focu.Core.Responses;

namespace Focu.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    
    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
        var message = result.IsSuccessStatusCode
            ? "Login successful"
            : "User or password incorrect";
        
        return new Response<string>(null, (int)result.StatusCode, message);
    }

    public async Task<Response<string>> RegisterAsync(RegisterRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/identity/register", request);
        var message = result.IsSuccessStatusCode
            ? "User registered successfully"
            : "Failed to register user";
        
        return new Response<string>(null, (int)result.StatusCode, message);
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        await _client.PostAsJsonAsync("v1/identity/logout", emptyContent);
    }
}
using System.Net.Http.Json;
using System.Security.Claims;
using Focu.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;

namespace Focu.Web.Security;

public class CookieAuthenticationStateProvider(IHttpClientFactory clientFactory) 
    : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private bool _isAuthenticated;
    private readonly HttpClient _client = clientFactory.CreateClient(WebConfiguration.HttpClientName);
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;

        var userInfo = await GetUserAsync();
        var user = userInfo is null 
            ? new ClaimsPrincipal(new ClaimsIdentity()) 
            : new ClaimsPrincipal(new ClaimsIdentity(await GetClaimsAsync(userInfo), nameof(CookieAuthenticationStateProvider)));

        _isAuthenticated = userInfo is not null;
        return new AuthenticationState(user);
    }
    
    private async Task<User?> GetUserAsync()
    {
        try 
        {
            return await _client.GetFromJsonAsync<User?>("v1/identity/manage/info");
        }
        catch(Exception exception)
        {
            return null;
        }
    }
    
    private async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        claims.AddRange(user.Claims
            .Where(x => x.Key is not (ClaimTypes.Name or ClaimTypes.Email or ClaimTypes.NameIdentifier))
            .Select(x => new Claim(x.Key, x.Value))
        );

        RoleClaim[] roles;
        try
        {
            roles = await _client.GetFromJsonAsync<RoleClaim[]>("v1/identity/manage/roles") ?? [];
        }
        catch
        {
            return claims;
        }
        
        claims.AddRange(roles
            .Where(role => !string.IsNullOrWhiteSpace(role.Type) && !string.IsNullOrWhiteSpace(role.Value))
            .Select(role => new Claim(role.Type!, role.Value!, role.ValueType, role.Issuer, role.OriginalIssuer)));

        return claims;
    }
    
    public async Task<bool> CheckAuthenticatedAsync()
    {
        await GetAuthenticationStateAsync();
        return _isAuthenticated;
    }

    public void NotifyAuthenticationStateChanged() => 
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}
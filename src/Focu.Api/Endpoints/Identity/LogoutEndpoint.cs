using Focu.Api.Common;
using Focu.Api.Data;
using Microsoft.AspNetCore.Identity;

namespace Focu.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/logout", HandleAsync);
    }
    
    private static async Task<IResult> HandleAsync(SignInManager<ApplicationUser> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.NoContent();
    }
}
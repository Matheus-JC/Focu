﻿using Focu.Api.Common;
using Focu.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace Focu.Api.IdentityContext.Endpoints;

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
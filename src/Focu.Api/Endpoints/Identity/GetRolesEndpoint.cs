﻿using System.Security.Claims;
using Focu.Api.Common;

namespace Focu.Api.Endpoints.Identity;

public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/roles", Handle);
    }
    
    private static IResult Handle(ClaimsPrincipal user)
    {
        if(user.Identity is null || !user.Identity.IsAuthenticated)
            return Results.Unauthorized();
        
        var identity = (ClaimsIdentity)user.Identity;
        
        var roles = identity
            .FindAll(identity.RoleClaimType)
            .Select(c => new 
            {
                c.Issuer,
                c.OriginalIssuer,
                c.Type,
                c.Value,
                c.ValueType
            });
        
        return Results.Ok(roles);
    }
}
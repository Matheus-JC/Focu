using System.Security.Claims;
using System.Security.Principal;

namespace Focu.Api.Extensions;

public static class IdentityExtensions
{
    public static Guid GetUserId(this IIdentity? identity)
    {
        var claimsIdentity = identity as ClaimsIdentity;
        var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
    }
}
using Microsoft.AspNetCore.Identity;

namespace Focu.Api.Data;

public class ApplicationUser : IdentityUser<Guid>
{
    public List<IdentityRole<Guid>>? Roles { get; init; } = [];
}
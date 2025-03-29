using Microsoft.AspNetCore.Identity;

namespace Focu.Infra.Data;

public class ApplicationUser : IdentityUser<Guid>
{
    public List<IdentityRole<Guid>>? Roles { get; set; } = [];
}
using EventfulPeace.Identity.AppRoles;
using EventfulPeace.Identity.AppUsers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Identity;

public class IdentityContext(DbContextOptions<IdentityContext> opt) : IdentityDbContext<AppUser, AppRole, Guid>(opt)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");
        builder.ApplyConfigurationsFromAssembly(IdentityReference.Assembly);
    }
}

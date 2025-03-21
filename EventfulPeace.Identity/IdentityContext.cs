using EventfulPeace.Domain.Users;
using EventfulPeace.Identity.AppRoles;
using EventfulPeace.Identity.AppUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Identity;

using static UserConstants.Ids;
using static UserConstants.Roles;

public class IdentityContext(DbContextOptions<IdentityContext> opt) : IdentityDbContext<AppUser, AppRole, Guid>(opt)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");
        builder.ApplyConfigurationsFromAssembly(IdentityReference.Assembly);
        builder.Entity<IdentityUserRole<Guid>>().HasData([
            new() { RoleId = IndividualId, UserId = Individual1.Value },
            new() { RoleId = IndividualId, UserId = Individual2.Value },
            new() { RoleId = OrganizationId, UserId = Organization1.Value },
            new() { RoleId = AdminId, UserId = Admin1.Value },
        ]);
    }
}

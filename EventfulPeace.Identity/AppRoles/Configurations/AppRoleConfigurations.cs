using EventfulPeace.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Identity.AppRoles.Configurations;

using static UserConstants.Roles;

public class AppRoleConfigurations : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
        => builder.HasData([
            CreateRole(IndividualId, Individual, "1a8ba0a7-4853-42da-980d-3107784e7ab1"),
            CreateRole(OrganizationId, Organization, "42174679-32f1-48b0-9524-0f00791ec760"),
            CreateRole(AdminId, Admin, "d6c9b3d1-8c3d-4a7e-8d6b-1b2c9c9c9c9c"),
        ]);

    private static AppRole CreateRole(Guid id, string name, string concStamp)
        => new()
        {
            Id = id,
            Name = name,
            NormalizedName = name.ToUpperInvariant(),
            ConcurrencyStamp = concStamp,
        };
}

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

using EventfulPeace.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Identity.AppUsers.Configurations;

using static UserConstants;

public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
        => builder.HasData([
            CreateUser(
                id: Ids.Individual1.Value,
                username: Usernames.Individual1,
                email: Emails.Individual1,
                passHash: "AQAAAAIAAYagAAAAEJFCGOTxNAgjhqU5lrA63WEtv924ujxXHt0x1R70qlS8dV9Pzz4II8GOgjVOaRzuDQ==",
                concStamp: "0c5bbfb2-d132-407b-9b1b-e1e640ccc14e",
                secStamp: "3A6TFN6VVZNRZEG22J777XJTPQY7342B"
            ),
            CreateUser(
                id: Ids.Individual2.Value,
                username: Usernames.Individual2,
                email: Emails.Individual2,
                passHash: "AQAAAAIAAYagAAAAEGjQ1Zes3r2XJgjoHQykiyr11OgUEDw+YDnOKeENyN7Kqi9RWKKRCtwd7ZtEyywdYA==",
                concStamp: "c77927de-61e7-4d53-be8d-a5390fafc75c",
                secStamp: "NWGZ3JTQSDNS346DMU7RP4IT4BDLHIQC"
            ),
            CreateUser(
                id: Ids.Organization1.Value,
                username: Usernames.Organization1,
                email: Emails.Organization1,
                passHash: "AQAAAAIAAYagAAAAEFqtQ33BvarNRyFcmV4z48fPBlIY8zd0de90qq3Cdm1Row+2WRmEjVJk1yPadBkrSA==",
                concStamp: "5c94b43f-861c-4efa-a670-5627e49d354d",
                secStamp: "YIA26UZDSN2V2U5PVDEK4F3EJS3P5D3X",
                phone: "0885566781"
            ),
        ]);

    private static AppUser CreateUser(Guid id, string username, string email, string passHash, string concStamp, string secStamp, string? phone = null)
        => new()
        {
            Id = id,
            UserName = username,
            NormalizedUserName = username.ToUpperInvariant(),
            Email = email,
            NormalizedEmail = email.ToUpperInvariant(),
            PasswordHash = passHash,
            AccessFailedCount = 0,
            EmailConfirmed = true,
            LockoutEnabled = true,
            PhoneNumber = phone,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            ConcurrencyStamp = concStamp,
            SecurityStamp = secStamp,
            LockoutEnd = null,
        };
}

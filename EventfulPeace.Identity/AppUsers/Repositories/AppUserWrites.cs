using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Users.Writes;
using Microsoft.AspNetCore.Identity;

namespace EventfulPeace.Identity.AppUsers.Repositories;

public class AppUserWrites(UserManager<AppUser> manager) : IUserWrites
{
    public async Task<UserId?> CreateAsync(string username, string email, string password, string role, string? phone = null)
    {
        AppUser user = new()
        {
            UserName = username,
            Email = email,
            PhoneNumber = phone,
        };

        IdentityResult createResult = await manager.CreateAsync(user, password).ConfigureAwait(false);
        if (!createResult.Succeeded)
        {
            return null;
        }

        IdentityResult roleResult = await manager.AddToRoleAsync(user, role).ConfigureAwait(false);
        if (!roleResult.Succeeded)
        {
            return null;
        }

        return UserId.New(user.Id);
    }
}

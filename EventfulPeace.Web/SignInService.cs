using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Application.Users;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Identity.AppUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Web;

public class SignInService(UserManager<AppUser> manager, SignInManager<AppUser> signIn)
    : ISignInService
{
    public async Task SignInAsync(UserId id, bool remember, CancellationToken ct = default)
        => await signIn.SignInAsync(
            isPersistent: remember,
            user: await manager.Users
                .FirstOrDefaultAsync(x => x.Id == id.Value, ct)
                .ConfigureAwait(false)
                ?? throw UserException.NotFound(id)
        ).ConfigureAwait(false);

    public async Task SignOutAsync(CancellationToken ct = default)
        => await signIn.SignOutAsync().ConfigureAwait(false);
}

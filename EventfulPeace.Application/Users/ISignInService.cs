
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Users;

public interface ISignInService
{
    Task SignInAsync(UserId id, bool remember, CancellationToken ct = default);
    Task SignOutAsync(CancellationToken ct = default);
}

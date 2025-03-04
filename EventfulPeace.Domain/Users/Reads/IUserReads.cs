using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;

namespace EventfulPeace.Domain.Users.Reads;

public interface IUserReads
{
    Task<Result<User>> AllAsync(bool track = true, CancellationToken ct = default);
    Task<Dictionary<UserId, User>> AllAsync(ICollection<UserId> ids, bool track = true, CancellationToken ct = default);
    Task<bool> CheckPasswordAsync(string username, string password);
    Task<User?> SingleAsync(UserId id, bool track = true, CancellationToken ct = default);
    Task<User?> SingleAsync(string username, bool track = true, CancellationToken ct = default);
}

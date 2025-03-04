using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Users.Writes;

public interface IUserWrites
{
    Task<UserId?> CreateAsync(string username, string email, string password, string role, string? phone = null);
}

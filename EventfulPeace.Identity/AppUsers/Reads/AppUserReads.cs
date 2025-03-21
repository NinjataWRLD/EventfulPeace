using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using EventfulPeace.Identity.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Identity.AppUsers.Reads;

public class AppUserReads(UserManager<AppUser> manager) : IUserReads
{
    public async Task<Result<User>> AllAsync(UsersQuery query, bool track = true, CancellationToken ct = default)
    {
        IQueryable<AppUser> queryable = manager.Users
            .WithTracking(track)
            .Where(x => x.UserName != null && x.Email != null);

        int page = query.Pagination.Page, limit = query.Pagination.Limit;
        int count = await queryable.CountAsync(ct).ConfigureAwait(false);

        User[] items = await queryable
            .Select(x => x.ToUser())
            .Skip((page - 1) * limit).Take(limit)
            .ToArrayAsync(ct)
            .ConfigureAwait(false);

        return new(
            Count: count,
            Items: items
        );
    }

    public async Task<Dictionary<UserId, User>> AllAsync(ICollection<UserId> ids, bool track = true, CancellationToken ct = default)
    {
        IQueryable<AppUser> queryable = manager.Users
            .WithTracking(track)
            .Where(x => x.UserName != null && x.Email != null);

        Guid[] idk = [.. ids.Select(x => x.Value)];
        Dictionary<UserId, User> users = await queryable
            .Where(x => idk.Contains(x.Id))
            .Select(x => x.ToUser())
            .ToDictionaryAsync(x => x.Id, x => x, ct)
            .ConfigureAwait(false);

        return users;
    }

    public async Task<bool> CheckPasswordAsync(string username, string password)
    {
        AppUser? user = await manager.FindByNameAsync(username).ConfigureAwait(false);
        if (user is null) return false;

        return await manager.CheckPasswordAsync(user, password);
    }

    public async Task<User?> SingleAsync(UserId id, bool track = true, CancellationToken ct = default)
        => (await manager.Users
            .WithTracking(track)
            .Where(x => x.UserName != null && x.Email != null)
            .FirstOrDefaultAsync(x => x.Id == id.Value, ct)
            .ConfigureAwait(false))
        ?.ToUser();

    public async Task<User?> SingleAsync(string username, bool track = true, CancellationToken ct = default)
        => (await manager.Users
            .WithTracking(track)
            .Where(x => x.UserName != null && x.Email != null)
            .FirstOrDefaultAsync(x => x.UserName == username, ct)
            .ConfigureAwait(false))
        ?.ToUser();
}

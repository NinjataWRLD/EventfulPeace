using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Enums;
using EventfulPeace.Persistence.ShadowEntities;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Persistence.Events.Reads;

public static class Utils
{
    public static IQueryable<Event> WithFilter(this IQueryable<Event> queryable, EventId[]? ids, UserId? creatorId, string? name)
    {
        if (ids is not null)
        {
            queryable = queryable.Where(x => ids.Contains(x.Id));
        }
        if (creatorId is not null)
        {
            queryable = queryable.Where(x => x.CreatorId == creatorId);
        }
        if (name is not null)
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        return queryable;
    }

    public static IQueryable<Event> WithSearch(this IQueryable<Event> queryable, string? name)
    {
        if (name is not null)
        {
            queryable = queryable.Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        return queryable;
    }

    public static IQueryable<Event> WithSorting(this IQueryable<Event> queryable, EventSorting sorting)
        => sorting switch
        {
            EventSorting.Alphabetical => queryable.OrderBy(x => x.Name),
            EventSorting.LastCreated => queryable.OrderByDescending(x => x.CreatedAt),
            EventSorting.FirstCreated => queryable.OrderBy(x => x.CreatedAt),
            EventSorting.LastOccus => queryable.OrderByDescending(x => x.OccursAt),
            EventSorting.FirstOccurs => queryable.OrderBy(x => x.OccursAt),
            _ => queryable,
        };

    public static IQueryable<Event> WithPagination(this IQueryable<Event> query, int page, int limit)
        => query.Skip((page - 1) * limit).Take(limit);

    public static async Task<EventId[]?> GeEventIdsByParticipantIdsOrDefaultAsync(this DbSet<Participant> set, UserId? participantId, CancellationToken ct = default)
        => participantId is not null
            ? await set
                .Where(x => participantId == x.ParticipantId)
                .GroupBy(x => x.EventId)
                .Where(x => x.Count() == 1)
                .Select(x => x.Key)
                .ToArrayAsync(ct)
                .ConfigureAwait(false)
            : null;
}

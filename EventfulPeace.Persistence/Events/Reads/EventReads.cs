using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Entities;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Persistence.Events.Reads;

public class EventReads(ApplicationContext context) : IEventReads
{
    public async Task<Result<Event>> AllAsync(EventsQuery query, bool track = true, CancellationToken ct = default)
    {
        EventId[]? ids = await context.Participants
            .GeEventIdsByParticipantIdsOrDefaultAsync(query.ParticipantId, ct)
            .ConfigureAwait(false);

        IQueryable<Event> queryable = context.Events
            .WithTracking(track)
            .Include(x => x.Location)
            .WithFilter(ids, query.CreatorId)
            .WithSearch(query.Name);

        int count = await queryable.CountAsync(ct).ConfigureAwait(false);
        Event[] items = await queryable
            .WithSorting(query.Sorting)
            .WithPagination(query.Pagination.Page, query.Pagination.Limit)
            .ToArrayAsync(ct)
            .ConfigureAwait(false);

        return new(
            Count: count,
            Items: items
        );
    }
    
    public async Task<Dictionary<string, Event[]>> AllByLocationAsync(bool track = true, CancellationToken ct = default)
    {
        IQueryable<Event> queryable = context.Events
            .WithTracking(track)
            .Include(x => x.Location);

        return await queryable
            .GroupBy(x => x.Location.Name)
            .ToDictionaryAsync(x => x.Key, x => x.ToArray(), ct)
            .ConfigureAwait(false);
    }

    public async Task<Location[]> AllLocationsAsync(CancellationToken ct = default)
        => await context.Locations
            .ToArrayAsync(ct)
            .ConfigureAwait(false);

    public async Task<Event?> SingleAsync(EventId id, bool track = true, CancellationToken ct = default)
        => await context.Events
            .WithTracking(track)
            .Include(x => x.Location)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            .ConfigureAwait(false);

    public async Task<UserId[]> ParticipantsByIdAsync(EventId id, CancellationToken ct = default)
        => await context.Participants
            .AsNoTracking()
            .Where(x => x.EventId == id)
            .Select(x => x.ParticipantId)
            .ToArrayAsync(ct)
            .ConfigureAwait(false);
}

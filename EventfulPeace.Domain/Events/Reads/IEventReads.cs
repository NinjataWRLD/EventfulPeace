using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events.Entities;

namespace EventfulPeace.Domain.Events.Reads;

public interface IEventReads
{
    Task<Result<Event>> AllAsync(EventsQuery query, bool track = true, CancellationToken ct = default);
    Task<Location[]> AllLocationsAsync(CancellationToken ct = default);
    Task<Dictionary<string, Event[]>> AllByLocationAsync(string? name = null, bool track = true, CancellationToken ct = default);
    Task<Event?> SingleAsync(EventId id, bool track = true, CancellationToken ct = default);
    Task<UserId[]> ParticipantsByIdAsync(EventId id, CancellationToken ct = default);
}

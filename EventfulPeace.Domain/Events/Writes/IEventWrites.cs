using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Events.Writes;

public interface IEventWrites
{
    public Task<Event> AddAsync(Event entity, CancellationToken ct = default);
    public Task JoinAsync(EventId id, UserId participantId, CancellationToken ct = default);
    public Task LeaveAsync(EventId id, UserId participantId, CancellationToken ct = default);
    public void Remove(Event entity);
}

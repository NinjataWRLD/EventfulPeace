using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Writes;
using EventfulPeace.Persistence.ShadowEntities;

namespace EventfulPeace.Persistence.Events.Writes;

public class EventWrites(ApplicationContext context) : IEventWrites
{
    public async Task<Event> AddAsync(Event entity, CancellationToken ct = default)
        =>
        (await context.Events.AddAsync(entity, ct).ConfigureAwait(false))
            .Entity;

    public async Task JoinAsync(EventId id, UserId participantId, CancellationToken ct = default)
        => await context.Participants.AddAsync(new(participantId, id), ct).ConfigureAwait(false);

    public void Remove(Event entity)
        => context.Events.Remove(entity);

    public async Task LeaveAsync(EventId id, UserId participantId, CancellationToken ct = default)
    {
        Participant? participant = await context.Participants.FindAsync(
            [participantId, id],
            ct
        ).ConfigureAwait(false);
        if (participant != null) context.Participants.Remove(participant);
    }
}

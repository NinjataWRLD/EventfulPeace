using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Persistence.ShadowEntities;

public class Participant
{
    private Participant() { }
    private Participant(UserId participantId, EventId eventId)
    {
        ParticipantId = participantId;
        EventId = eventId;
    }

    public UserId ParticipantId { get; set; }
    public EventId EventId { get; set; }

    public static Participant Create(UserId participantId, EventId eventId)
        => new(participantId, eventId);
}

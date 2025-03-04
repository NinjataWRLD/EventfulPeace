using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Invitations;

public class Invitation
{
    private Invitation() { }
    private Invitation(UserId senderId, UserId recieverId, EventId eventId)
    {
        SenderId = senderId;
        ReceiverId = recieverId;
        SentAt = DateTime.UtcNow;
        EventId = eventId;
    }

    public InvitationId Id { get; private set; }
    public DateTime SentAt { get; private set; }
    public UserId SenderId { get; private set; }
    public UserId ReceiverId { get; private set; }
    public EventId EventId { get; private set; }

    public static Invitation Create(UserId senderId, UserId recieverId, EventId eventId)
        => new(senderId, recieverId, eventId);
}

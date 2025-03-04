namespace EventfulPeace.Domain.Invitations.Reads;

public interface IInvitationReads
{
    Task<ICollection<Invitation>> AllAsync(InvitationsQuery query, bool track = true, CancellationToken ct = default);
}

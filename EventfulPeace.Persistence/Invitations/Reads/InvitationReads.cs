using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Invitations;
using EventfulPeace.Domain.Invitations.Reads;
using EventfulPeace.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Persistence.Invitations.Reads;

public class InvitationReads(ApplicationContext context) : IInvitationReads
{
    public async Task<ICollection<Invitation>> AllAsync(InvitationsQuery query, bool track = true, CancellationToken ct = default)
    {
        IQueryable<Invitation> queryable = context.Invitations
            .WithTracking(track)
            .WithFilter(query.SenderId, query.ReceiverId);

        Invitation[] invitations = await queryable
            .WithSorting(query.Sorting)
            .ToArrayAsync(ct)
            .ConfigureAwait(false);

        return invitations;
    }

    public async Task<Invitation?> SingleAsync(InvitationId id, bool track = true, CancellationToken ct = default)
        => await context.Invitations
            .WithTracking(track)
            .FirstOrDefaultAsync(x => x.Id == id, ct)
            .ConfigureAwait(false);
}

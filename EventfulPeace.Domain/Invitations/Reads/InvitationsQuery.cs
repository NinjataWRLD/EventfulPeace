using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Invitations.Enums;

namespace EventfulPeace.Domain.Invitations.Reads;

public record InvitationsQuery(
    UserId? ReceiverId = null,
    UserId? SenderId = null,
    InvitationSorting Sorting = InvitationSorting.LastSent
);

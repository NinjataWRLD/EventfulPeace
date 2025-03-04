using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Invitations;
using EventfulPeace.Domain.Invitations.Enums;

namespace EventfulPeace.Persistence.Invitations.Reads;

public static class Utils
{
    public static IQueryable<Invitation> WithFilter(this IQueryable<Invitation> queryable, UserId? senderId, UserId? receiverId)
    {
        if (senderId is not null)
        {
            queryable = queryable.Where(x => x.SenderId == senderId);
        }
        if (receiverId is not null)
        {
            queryable = queryable.Where(x => x.ReceiverId == receiverId);
        }

        return queryable;
    }

    public static IQueryable<Invitation> WithSorting(this IQueryable<Invitation> queryable, InvitationSorting sorting)
        => sorting switch
        {
            InvitationSorting.LastSent => queryable.OrderByDescending(x => x.SentAt),
            InvitationSorting.FirstSent => queryable.OrderBy(x => x.SentAt),
            _ => queryable,
        };
}

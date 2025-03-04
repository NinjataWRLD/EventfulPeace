using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.GetAll;

public class GetAllEventsUseCase(IEventReads eventReads, IUserReads userReads)
    : IRequestHandler<GetAllEventsRequest, Result<GetAllEventsDto>>
{
    public async Task<Result<GetAllEventsDto>> Handle(GetAllEventsRequest req, CancellationToken ct)
    {
        EventsQuery query = new(
            Pagination: req.Pagination,
            Name: req.Name,
            CreatorId: req.CreatorId,
            Sorting: req.Sorting
        );
        Result<Event> result = await eventReads.AllAsync(query, track: false, ct: ct).ConfigureAwait(false);

        UserId[] userIds = [.. result.Items.Select(x => x.CreatorId).Distinct()];
        Dictionary<UserId, User> users = await userReads.AllAsync(userIds, ct: ct).ConfigureAwait(false);

        UserDto MapUser(UserId id) => users[id].ToDto();
        GetAllEventsDto MapEvent(Event e, UserDto user) => e.ToDto(user);

        return new(
            Count: result.Count,
            Items: [.. 
                result.Items.Select(x => MapEvent(x, MapUser(x.CreatorId)))
            ]
        );
    }
}
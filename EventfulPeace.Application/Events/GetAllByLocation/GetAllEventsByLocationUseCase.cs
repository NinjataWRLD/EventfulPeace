using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.GetAllByLocation;

public class GetAllEventsByLocationUseCase(IEventReads eventReads, IUserReads userReads)
    : IRequestHandler<GetAllEventsByLocationRequest, Dictionary<string, GetAllEventsByLocationDto[]>>
{
    public async Task<Dictionary<string, GetAllEventsByLocationDto[]>> Handle(GetAllEventsByLocationRequest req, CancellationToken ct)
    {
        Dictionary<string, Event[]> dict = await eventReads.AllByLocationAsync(track: false, ct: ct).ConfigureAwait(false);

        UserId[] userIds = [.. dict.Values.SelectMany(x => x.Select(x => x.CreatorId)).Distinct()];
        Dictionary<UserId, User> users = await userReads.AllAsync(userIds, ct: ct).ConfigureAwait(false);

        UserDto MapUser(UserId id) => users[id].ToDto();
        GetAllEventsByLocationDto MapEvent(Event e, UserDto user) => e.ToDto(user);

        return dict.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(x => MapEvent(x, MapUser(x.CreatorId))).ToArray()
        );
    }
}
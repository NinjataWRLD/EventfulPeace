using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Application.Events.GetAllByLocation;
using EventfulPeace.Domain.Events;

namespace EventfulPeace.Application.Events.GetAllByLocation;

internal static class GetAllEventsByLocationMapper
{
    internal static GetAllEventsByLocationDto ToDto(this Event @event, UserDto creator, bool isMapper = false)
        => new(
            Id: @event.Id,
            Name: @event.Name,
            OccursAt: @event.OccursAt,
            Location: isMapper ? null! : @event.Location.ToDto(),
            Creator: creator
        );
}

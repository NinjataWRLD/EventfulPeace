using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Events;

namespace EventfulPeace.Application.Events.GetAll;

internal static class GetAllEventsMapper
{
    internal static GetAllEventsDto ToDto(this Event @event, UserDto creator, bool isMapper = false)
        => new(
            Id: @event.Id,
            Name: @event.Name,
            OccursAt: @event.OccursAt,
            Location: isMapper ? null! : @event.Location.ToDto(),
            Creator: creator
        );
}

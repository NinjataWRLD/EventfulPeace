using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Application.Events.GetSingle;
using EventfulPeace.Domain.Events;

namespace EventfulPeace.Application.Events.GetSingle;

internal static class GetSingleEventMapper
{
    internal static GetSingleEventDto ToDto(this Event @event, UserDto creator, UserDto[] participants)
        => new(
            Id: @event.Id,
            Name: @event.Name,
            Description: @event.Description,
            OccursAt: @event.OccursAt,
            CreatedAt: @event.CreatedAt,
            Location: @event.Location.ToDto(),
            Creator: creator,
            Participants: participants
        );
}

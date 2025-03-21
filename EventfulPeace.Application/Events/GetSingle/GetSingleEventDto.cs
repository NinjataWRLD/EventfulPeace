using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Events.GetSingle;

public record GetSingleEventDto(
    EventId Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime OccursAt,
    LocationDto Location,
    UserDto Creator,
    UserDto[] Participants,
    ImageDto Image
);

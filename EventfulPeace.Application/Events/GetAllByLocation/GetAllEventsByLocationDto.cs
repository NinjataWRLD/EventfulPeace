using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Events.GetAllByLocation;

public record GetAllEventsByLocationDto(
    EventId Id,
    string Name,
    DateTime OccursAt,
    LocationDto Location,
    UserDto Creator
);

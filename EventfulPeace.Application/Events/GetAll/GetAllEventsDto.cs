using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Events.GetAll;

public record GetAllEventsDto(
    EventId Id,
    string Name,
    DateTime OccursAt,
    LocationDto Location,
    UserDto Creator
);

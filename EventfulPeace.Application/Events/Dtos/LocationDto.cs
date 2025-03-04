using EventfulPeace.Application.Events.GetAll;
using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Events.Dtos;

public record LocationDto(
    LocationId Id,
    string Name
);

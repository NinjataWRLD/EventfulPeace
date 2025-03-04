using EventfulPeace.Domain.Events.Entities;

namespace EventfulPeace.Application.Events.Dtos;

internal static class Mapper
{
    public static LocationDto ToDto(this Location location)
        => new(
            Id: location.Id,
            Name: location.Name
        );
}

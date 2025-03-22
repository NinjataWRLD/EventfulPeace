using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Events.Dtos;

namespace EventfulPeace.Web.Models;

public record EventModel(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime OccursAt,
    LocationDto Location,
    UserDto Creator,
    UserDto[] Participants,
    FileModel File
);

using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Common.Dtos;

public record UserDto(
    UserId Id,
    string Name,
    string Email,
    string Role,
    string? Phone
);

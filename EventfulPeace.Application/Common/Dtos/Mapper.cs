using EventfulPeace.Domain.Users;

namespace EventfulPeace.Application.Common.Dtos;

internal static class Mapper
{
    internal static UserDto ToDto(this User user)
        => new(
            Id: user.Id,
            Name: user.Name,
            Email: user.Email,
            Role: user.Role,
            Phone: user.Phone
        );
}

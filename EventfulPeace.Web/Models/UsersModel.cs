using EventfulPeace.Application.Common.Dtos;

namespace EventfulPeace.Web.Models;

public record UsersModel(
    UserDto[] Users,
    int Total,
    int Page = 1,
    int Limit = 5
);

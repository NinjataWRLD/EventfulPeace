using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Domain.Common.ValueObjects;
using MediatR;

namespace EventfulPeace.Application.Users.GetAll;

public record GetAllUsersRequest(
    Pagination Pagination
) : IRequest<Result<UserDto>>;

using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using MediatR;

namespace EventfulPeace.Application.Users.GetAll;

public class GetAllUsersUseCase(IUserReads reads)
    : IRequestHandler<GetAllUsersRequest, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetAllUsersRequest req, CancellationToken ct)
    {
        Result<User> users = await reads.AllAsync(new UsersQuery(
            Pagination: req.Pagination
        ), track: false, ct).ConfigureAwait(false);

        return new(
            Count: users.Count,
            Items: [.. users.Items.Select(u => u.ToDto())]
        );
    }
}

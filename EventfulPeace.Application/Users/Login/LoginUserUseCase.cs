using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using MediatR;

namespace EventfulPeace.Application.Users.Login;

public class LoginUserUseCase(IUserReads reads, ISignInService service)
    : IRequestHandler<LoginUserRequest>
{
    public async Task Handle(LoginUserRequest req, CancellationToken ct)
    {
        User user = await reads.SingleAsync(req.Username, ct: ct).ConfigureAwait(false)
            ?? throw UserException.NotFound(req.Username);

        if (!await reads.CheckPasswordAsync(req.Username, req.Password).ConfigureAwait(false))
        {
            throw UserException.IncorrectLogin(user.Name);
        }
        await service.SignInAsync(user.Id, req.RememberMe, ct).ConfigureAwait(false);
    }
}

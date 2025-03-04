using MediatR;

namespace EventfulPeace.Application.Users.Logout;

public class LogoutUserUseCase(ISignInService signIn)
    : IRequestHandler<LogoutUserRequest>
{
    public async Task Handle(LogoutUserRequest req, CancellationToken ct)
    {
        await signIn.SignOutAsync(ct);
    }
}

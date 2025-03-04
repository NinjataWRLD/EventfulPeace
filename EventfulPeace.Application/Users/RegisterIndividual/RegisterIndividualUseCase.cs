using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Writes;
using MediatR;

namespace EventfulPeace.Application.Users.RegisterIndividual;

using static UserConstants.Roles;

public class RegisterIndividualUseCase(IUserWrites writes, ISignInService signIn)
    : IRequestHandler<RegisterIndividualRequest>
{
    public async Task Handle(RegisterIndividualRequest req, CancellationToken ct)
    {
        UserId id = await writes.CreateAsync(
            req.Username,
            req.Email,
            req.Password,
            Individual
        ).ConfigureAwait(false)
        ?? throw UserException.InvalidRegister(req.Username);

        await signIn.SignInAsync(id, false, ct).ConfigureAwait(false);
    }
}

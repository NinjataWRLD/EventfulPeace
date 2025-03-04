using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Writes;
using MediatR;

namespace EventfulPeace.Application.Users.RegisterOrganization;

using static UserConstants.Roles;

public class RegisterOrganizationUseCase(IUserWrites writes, ISignInService signIn)
    : IRequestHandler<RegisterOrganizationRequest>
{
    public async Task Handle(RegisterOrganizationRequest req, CancellationToken ct)
    {
        UserId id = await writes.CreateAsync(
            req.Username,
            req.Email,
            req.Password,
            Organization,
            req.Phone
        ).ConfigureAwait(false)
        ?? throw UserException.InvalidRegister(req.Username);

        await signIn.SignInAsync(id, false, ct).ConfigureAwait(false);
    }
}

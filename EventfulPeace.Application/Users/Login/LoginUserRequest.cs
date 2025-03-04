using MediatR;

namespace EventfulPeace.Application.Users.Login;

public record LoginUserRequest(
    string Username,
    string Password,
    bool RememberMe
) : IRequest;

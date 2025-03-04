using MediatR;

namespace EventfulPeace.Application.Users.RegisterIndividual;

public record RegisterIndividualRequest(
    string Username,
    string Email,
    string Password
) : IRequest;

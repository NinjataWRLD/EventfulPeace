using MediatR;

namespace EventfulPeace.Application.Users.RegisterOrganization;

public record RegisterOrganizationRequest(
    string Username,
    string Email,
    string Password,
    string Phone
) : IRequest;

using EventfulPeace.Domain.Common.ValueObjects;

namespace EventfulPeace.Domain.Users.Reads;

public record UsersQuery(
    Pagination Pagination
);

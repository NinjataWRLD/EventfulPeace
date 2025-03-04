namespace EventfulPeace.Domain.Common.ValueObjects;

public record Pagination(
    int Limit,
    int Page
);

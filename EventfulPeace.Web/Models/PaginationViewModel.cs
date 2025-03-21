namespace EventfulPeace.Web.Models;

public record PaginationViewModel(
    int Page,
    int Limit,
    int Total
);

namespace EventfulPeace.Domain.Common.ValueObjects;

public record Result<TItem>(
    int Count,
    ICollection<TItem> Items
);

using System.Diagnostics.CodeAnalysis;

namespace EventfulPeace.Domain.Common.TypedIds;

public readonly struct UserId
{
    public UserId() : this(Guid.Empty) { }
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId New(Guid value) => new(value);
    public static UserId New(string? id) => id is null ? new() : new(Guid.Parse(id));
    public static UserId New() => new(Guid.NewGuid());

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is UserId id && this == id;

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public static bool operator ==(UserId left, UserId right)
        => left.Value == right.Value;

    public static bool operator !=(UserId left, UserId right)
        => !(left == right);
}

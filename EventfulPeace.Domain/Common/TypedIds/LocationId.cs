using System.Diagnostics.CodeAnalysis;

namespace EventfulPeace.Domain.Common.TypedIds;

public readonly struct LocationId
{
    public LocationId() : this(Guid.Empty) { }
    private LocationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static LocationId New(Guid value) => new(value);
    public static LocationId New() => new(Guid.NewGuid());

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is LocationId id && this == id;

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public static bool operator ==(LocationId left, LocationId right)
        => left.Value == right.Value;

    public static bool operator !=(LocationId left, LocationId right)
        => !(left == right);
}

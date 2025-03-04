using System.Diagnostics.CodeAnalysis;

namespace EventfulPeace.Domain.Common.TypedIds;

public readonly struct EventId
{
    public EventId() : this(Guid.Empty) { }
    private EventId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static EventId New(Guid value) => new(value);
    public static EventId New() => new(Guid.NewGuid());

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is EventId id && this == id;

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public static bool operator ==(EventId left, EventId right)
        => left.Value == right.Value;

    public static bool operator !=(EventId left, EventId right)
        => !(left == right);
}

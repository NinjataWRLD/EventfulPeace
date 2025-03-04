using System.Diagnostics.CodeAnalysis;

namespace EventfulPeace.Domain.Common.TypedIds;

public readonly struct InvitationId
{
    public InvitationId() : this(Guid.Empty) { }
    private InvitationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static InvitationId New(Guid value) => new(value);
    public static InvitationId New() => new(Guid.NewGuid());

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is InvitationId id && this == id;

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public static bool operator ==(InvitationId left, InvitationId right)
        => left.Value == right.Value;

    public static bool operator !=(InvitationId left, InvitationId right)
        => !(left == right);
}

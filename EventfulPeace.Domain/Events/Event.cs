using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events.Entities;

namespace EventfulPeace.Domain.Events;

public sealed class Event
{
    private Event() { }
    private Event(
        string name,
        string description,
        DateTime occursAt,
        UserId creatorId,
        LocationId locationId,
        DateTime? createdAt
    )
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        OccursAt = occursAt;
        CreatorId = creatorId;
        LocationId = locationId;
    }

    public EventId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime OccursAt { get; private set; }
    public UserId CreatorId { get; private set; }
    public LocationId LocationId { get; private set; }
    public Location Location { get; private set; } = null!;

    public static Event Create(
        string name,
        string description,
        DateTime occursAt,
        LocationId locationId,
        UserId creatorId
    ) => new(name, description, occursAt, creatorId, locationId, null);

    public static Event Create(
        EventId id,
        string name,
        string description,
        DateTime occursAt,
        LocationId locationId,
        UserId creatorId,
        DateTime createdAt
    ) => new(name, description, occursAt, creatorId, locationId, createdAt)
    {
        Id = id
    };
}

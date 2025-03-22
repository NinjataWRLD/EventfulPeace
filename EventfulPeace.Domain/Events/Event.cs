using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events.Entities;

namespace EventfulPeace.Domain.Events;

public sealed class Event
{
    private Event() { }
    private Event(
        string name,
        string description,
        string imageKey,
        string imageContentType,
        DateTime occursAt,
        UserId creatorId,
        LocationId locationId,
        DateTime? createdAt
    )
    {
        Name = name;
        Description = description;
        ImageKey = imageKey;
        ImageContentType = imageContentType;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        OccursAt = occursAt;
        CreatorId = creatorId;
        LocationId = locationId;
    }

    public EventId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string ImageKey { get; private set; } = string.Empty;
    public string ImageContentType { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime OccursAt { get; private set; }
    public UserId CreatorId { get; private set; }
    public LocationId LocationId { get; private set; }
    public Location Location { get; private set; } = null!;

    public static Event Create(
        string name,
        string description,
        string imageKey,
        string imageContentType,
        DateTime occursAt,
        LocationId locationId,
        UserId creatorId
    ) => new(name, description, imageKey, imageContentType, occursAt, creatorId, locationId, null);

    public static Event Create(
        EventId id,
        string name,
        string description,
        string imageExtension,
        string imageContentType,
        DateTime occursAt,
        LocationId locationId,
        UserId creatorId,
        DateTime createdAt
    ) => new(name, description, $"images/{name}-{id}{imageExtension}", imageContentType, occursAt, creatorId, locationId, createdAt)
    {
        Id = id
    };

    public Event SetName(string name)
    {
        Name = name;
        return this;
    }

    public Event SetDescription(string description)
    {
        Description = description;
        return this;
    }
    
    public Event SetOccursAt(DateTime occursAt)
    {
        OccursAt = occursAt;
        return this;
    }

    public Event SetLocationId(LocationId locationId)
    {
        LocationId = locationId;
        return this;
    }
}

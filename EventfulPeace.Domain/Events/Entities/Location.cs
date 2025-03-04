using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Events.Entities;

public sealed class Location
{
    private readonly List<Event> events = [];

    private Location() { }
    private Location(string name)
    {
        Name = name;
    }

    public LocationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public IReadOnlyCollection<Event> Events => events.AsReadOnly();

    public static Location Create(string name)
        => new(name);

    public static Location Create(LocationId id, string name)
        => new(name) { Id = id };
}
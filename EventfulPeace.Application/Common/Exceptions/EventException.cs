using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Common.Exceptions;

public class EventException : Exception
{
    private EventException(string? message, Exception? ex) : base(message, ex) { }

    public static EventException NotFound(EventId id, Exception? ex = null)
        => new($"Event with id: {id} not found.", ex);
}

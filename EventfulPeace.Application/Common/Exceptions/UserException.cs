using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Application.Common.Exceptions;

public class UserException : Exception
{
    private UserException(string? message, Exception? ex) : base(message, ex) { }

    public static UserException NotFound(UserId id, Exception? ex = null)
        => new($"User with id: {id} not found.", ex);

    public static UserException NotFound(string username, Exception? ex = null)
        => new($"User with username: {username} not found.", ex);

    public static UserException InvalidRegister(string username, Exception? ex = null)
        => new($"Couldn't register User: {username}.", ex);

    public static UserException IncorrectLogin(string username, Exception? ex = null)
        => new($"Couldn't log in as User: {username}. Incorrect username or password.", ex);
}

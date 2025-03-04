using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Users;

using static UserConstants.Roles;

public sealed class User
{
    private User(string name, string email, string role, string? phone)
    {
        Name = name;
        Email = email;
        Role = role;
        Phone = phone;
    }

    public UserId Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string? Phone { get; init; } = string.Empty;

    public static User Create(string name, string email)
        => new(name, email, Individual, null);
    
    public static User Create(UserId id, string name, string email)
        => new(name, email, Individual, null) { Id = id };

    public static User Create(string name, string email, string phone)
        => new(name, email, Organization, phone);

    public static User Create(UserId id, string name, string email, string phone)
        => new(name, email, Organization, phone) { Id = id };
}

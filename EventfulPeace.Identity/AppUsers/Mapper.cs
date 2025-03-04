using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Users;

namespace EventfulPeace.Identity.AppUsers;

public static class Mapper
{
    public static User ToUser(this AppUser user)
        => user.PhoneNumber != null
                ? User.Create(UserId.New(user.Id), user.UserName!, user.Email!, user.PhoneNumber)
                : User.Create(UserId.New(user.Id), user.UserName!, user.Email!);
}

using EventfulPeace.Domain.Common.TypedIds;
using System.Text.RegularExpressions;

namespace EventfulPeace.Domain.Users;

public static partial class UserConstants
{
    public const int UsernameMaxLength = 62;
    public const int UsernameMinLength = 2;

    public static Regex Email => EmailRegex();
    public static Regex Phone => PhoneRegex();

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled)]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"^\+?[1-9]\d{1,14}$", RegexOptions.Compiled)]
    private static partial Regex PhoneRegex();

    public static class Ids
    {
        public static readonly UserId Individual1 = UserId.New(Guid.Parse("2c7667ad-716b-4606-b50d-a370ecdb1a00"));
        public static readonly UserId Individual2 = UserId.New(Guid.Parse("7f6e3868-ca03-44d6-b4a3-d947ac012ca6"));
        public static readonly UserId Organization1 = UserId.New(Guid.Parse("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"));
        public static readonly UserId Admin1 = UserId.New(Guid.Parse("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90"));
    }
    
    public static class Usernames
    {
        public const string Individual1 = "NinjataBG";
        public const string Individual2 = "Ivayla-G";
        public const string Organization1 = "YICBurgas";
        public const string Admin1 = "Admin123";
    }
    
    public static class Emails
    {
        public const string Individual1 = "ivanangelov414@gmail.com";
        public const string Individual2 = "ighristova5@gmail.com";
        public const string Organization1 = "office@yicburgas.bg";
        public const string Admin1 = "admin123@gmail.com";
    }

    public static class Roles
    {
        public const string Individual = "Individual";
        public const string Organization = "Organization";
        public const string Admin = "Admin";
        public static readonly Guid IndividualId = Guid.Parse("f3ad41d3-ee90-4988-9195-8b2a8f4f2733");
        public static readonly Guid OrganizationId = Guid.Parse("fad1b19d-5333-4633-bd84-d67c64649f65");
        public static readonly Guid AdminId = Guid.Parse("fab1b19d-5333-4633-bd84-d67c64649f65");
    }
}

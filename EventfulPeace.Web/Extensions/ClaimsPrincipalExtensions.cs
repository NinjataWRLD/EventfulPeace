using EventfulPeace.Domain.Common.TypedIds;
using System.Security.Claims;

namespace EventfulPeace.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static UserId GetUserId(this ClaimsPrincipal user)
        => UserId.New(user.FindFirstValue(ClaimTypes.NameIdentifier));

    public static string GetName(this ClaimsPrincipal user)
        => user.Identity?.Name ?? string.Empty;

    public static bool GetAuthentication(this ClaimsPrincipal user)
        => user.Identity?.IsAuthenticated ?? false;

    public static string? GetAuthorization(this ClaimsPrincipal user)
        => user.FindFirstValue(ClaimTypes.Role);
}


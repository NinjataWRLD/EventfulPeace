using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Identity.Common;

public static class Utils
{
    public static IQueryable<TEntity> WithTracking<TEntity>(this IQueryable<TEntity> set, bool track = true) where TEntity : class
        => track ? set : set.AsNoTracking();
}

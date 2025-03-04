using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Persistence.Common;

public static class Utils
{
    public static IQueryable<TEntity> WithTracking<TEntity>(this DbSet<TEntity> set, bool tracking) where TEntity : class
        => tracking ? set : set.AsNoTracking();
}

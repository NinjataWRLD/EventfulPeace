using EventfulPeace.Domain.Common.Repositories;

namespace EventfulPeace.Persistence.Common;

public class Writes<TEntity>(ApplicationContext context) : IWrites<TEntity>
    where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
        => (await context.Set<TEntity>().AddAsync(entity, ct).ConfigureAwait(false)).Entity;

    public void Remove(TEntity entity)
        => context.Set<TEntity>().Remove(entity);
}

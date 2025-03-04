namespace EventfulPeace.Domain.Common.Repositories;

public interface IWrites<TEntity> where TEntity : class
{
    public Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
    public void Remove(TEntity entity);
}

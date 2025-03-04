namespace EventfulPeace.Domain.Common.Repositories;


public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken ct = default);
}

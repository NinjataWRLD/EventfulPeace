using EventfulPeace.Domain.Common.Repositories;

namespace EventfulPeace.Persistence.Common;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default)
        => await context.SaveChangesAsync(ct).ConfigureAwait(false);
}

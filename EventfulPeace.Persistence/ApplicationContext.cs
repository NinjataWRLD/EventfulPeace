using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Entities;
using EventfulPeace.Domain.Invitations;
using EventfulPeace.Persistence.ShadowEntities;
using Microsoft.EntityFrameworkCore;

namespace EventfulPeace.Persistence;

public class ApplicationContext(DbContextOptions<ApplicationContext> opts) : DbContext(opts)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Invitation> Invitations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Application");
        builder.ApplyConfigurationsFromAssembly(PersistenceReference.Assembly);
    }
}

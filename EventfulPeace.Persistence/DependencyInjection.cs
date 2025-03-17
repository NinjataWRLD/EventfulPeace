using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Domain.Events.Writes;
using EventfulPeace.Domain.Invitations.Reads;
using EventfulPeace.Persistence;
using EventfulPeace.Persistence.Common;
using EventfulPeace.Persistence.Events.Reads;
using EventfulPeace.Persistence.Events.Writes;
using EventfulPeace.Persistence.Invitations.Reads;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#pragma warning disable IDE0130
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static async Task<IServiceProvider> UpdateApplicationContextAsync(this IServiceProvider provider)
    {
        ApplicationContext context = provider.GetRequiredService<ApplicationContext>();
        await context.Database.MigrateAsync().ConfigureAwait(false);

        return provider;
    }

    public static IServiceCollection AddApplicationPersistence(this IServiceCollection services, IConfiguration config)
        => services
            .AddContext(config)
            .AddReads()
            .AddWrites()
            .AddUnitOfWork();

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("ApplicationConnection")
                ?? throw new KeyNotFoundException("Could not find connection string 'ApplicationConnection'.");

        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString, opt =>
                opt.MigrationsHistoryTable("__EFMigrationsHistory", "Application")
            )
        );

        return services;
    }

    private static IServiceCollection AddReads(this IServiceCollection services)
    {
        services.AddScoped<IEventReads, EventReads>();
        services.AddScoped<IInvitationReads, InvitationReads>();

        return services;
    }

    private static IServiceCollection AddWrites(this IServiceCollection services)
    {
        services.AddScoped<IEventWrites, EventWrites>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

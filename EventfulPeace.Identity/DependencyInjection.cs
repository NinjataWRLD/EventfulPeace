#pragma warning disable IDE0130
using EventfulPeace.Domain.Users.Reads;
using EventfulPeace.Domain.Users.Writes;
using EventfulPeace.Identity;
using EventfulPeace.Identity.AppUsers.Reads;
using EventfulPeace.Identity.AppUsers.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static async Task<IServiceProvider> UpdateIdentityContextAsync(this IServiceProvider provider)
    {
        IdentityContext context = provider.GetRequiredService<IdentityContext>();
        await context.Database.MigrateAsync().ConfigureAwait(false);

        return provider;
    }

    public static IServiceCollection AddIdentityPersistence(this IServiceCollection services, IConfiguration config)
        => services
            .AddContext(config)
            .AddReads()
            .AddWrites();

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("IdentityConnection")
            ?? throw new KeyNotFoundException("Could not find connection string 'IdentityConnection'.");

        services.AddDbContext<IdentityContext>(options =>
            options.UseNpgsql(connectionString, opt =>
                opt.MigrationsHistoryTable("__EFMigrationsHistory", "Identity")
            )
        );

        return services;
    }

    private static IServiceCollection AddReads(this IServiceCollection services)
    {
        services.AddScoped<IUserReads, AppUserReads>();

        return services;
    }

    private static IServiceCollection AddWrites(this IServiceCollection services)
    {
        services.AddScoped<IUserWrites, AppUserWrites>();

        return services;
    }
}

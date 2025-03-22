using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using CustomCADs.Shared.Infrastructure.Storage;
using EventfulPeace.Application;
using EventfulPeace.Application.Common;
using EventfulPeace.Application.Middleware;
using EventfulPeace.Application.Users;
using EventfulPeace.Identity;
using EventfulPeace.Identity.AppRoles;
using EventfulPeace.Identity.AppUsers;
using EventfulPeace.Web;
using EventfulPeace.Web.Hubs;
using EventfulPeace.Web.Storage;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Reflection;

#pragma warning disable IDE0130
namespace Microsoft.Extensions.DependencyInjection;

public static class ProgramExtensions
{
    public static AuthenticationBuilder AddAuthN(this IServiceCollection services)
    {
        AuthenticationBuilder builder = services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

        return builder;
    }

    public static void AddAuthZ(this IServiceCollection services, IEnumerable<string> roles)
    {
        services.AddAuthorization(options =>
        {
            foreach (string role in roles)
            {
                options.AddPolicy(role, policy => policy.RequireRole(role));
            }
        });
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        Assembly[] assemblies = [
            ApplicationReference.Assembly,
        ];

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(ApplicationReference.Assembly));
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }

    public static void AddStorage(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<StorageSettings>(config.GetSection("Storage"));
        services.AddSingleton<IAmazonS3>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<StorageSettings>>().Value;

            AmazonS3Config config = new()
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(settings.Region),
            };

            BasicAWSCredentials credentials = new(settings.AccessKey, settings.SecretKey);
            return new AmazonS3Client(credentials, config);
        });
        services.AddScoped<IStorageService, AmazonS3Service>();
        services.AddHttpClient("StorageClient");
    }

    public static async Task AddDbMigrationUpdater(this IServiceCollection services)
    {
        using IServiceScope scope = services.BuildServiceProvider().CreateScope();
        IServiceProvider provider = scope.ServiceProvider;

        await Task.WhenAll([
            provider.UpdateApplicationContextAsync(),
            provider.UpdateIdentityContextAsync(),
        ]).ConfigureAwait(false);
    }
    private static IServiceCollection AddIdentityConfigs(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+" + ' '; // default + space
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        })
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();

        return services;
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddApplicationPersistence(config);
        services.AddIdentityPersistence(config).AddIdentityConfigs();
        services.AddScoped<ISignInService, SignInService>();
    }

    public static IEndpointRouteBuilder MapSignalRHubs(this IEndpointRouteBuilder app)
    {
        app.MapHub<EventsHub>("/eventsHub");
        app.MapHub<UsersHub>("/usersHub");

        return app;
    }
}

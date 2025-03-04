using EventfulPeace.Web.Extensions;
using static EventfulPeace.Domain.Users.UserConstants.Roles;

var builder = WebApplication.CreateBuilder(args);

// Necessary services
builder.Services.AddAuthN().AddCookie();
builder.Services.AddAuthZ([Individual, Organization]);

// Project Layers
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUseCases();

// Database Updater
if (args.Contains("--migrate"))
{
    await builder.Services.AddDbMigrationUpdater().ConfigureAwait(false);
}
else if (args.Contains("--migrate-only"))
{
    await builder.Services.AddDbMigrationUpdater().ConfigureAwait(false);
    return;
}

// Web app
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

await app.RunAsync().ConfigureAwait(false);

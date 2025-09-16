using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Contexts.Seeds;
using GraphQL.Server.Extensions.ServiceExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddServices(builder.Configuration)
    .AddGraphQl()
    .RegisterAuthenticationScheme(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var applicationContextSeed = scope.ServiceProvider.GetRequiredService<ApplicationContextSeed>();
    await applicationContextSeed.InitialiseAsync();
    await applicationContextSeed.SeedAsync();
}

app.UseWebSockets();

app.UseRouting();

app.UseAuthentication();

app.MapGraphQL();
app.RunWithGraphQLCommands(args);

app.Run();
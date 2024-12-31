using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.Data.Contexts.Seeds;

public class ApplicationContextSeed
{
    private readonly ILogger<ApplicationContextSeed> _logger;
    private readonly ApplicationDbContext _dbContext;

    public ApplicationContextSeed(ILogger<ApplicationContextSeed> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _logger = logger;
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_dbContext.Database.IsSqlServer())
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError("An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        await new TestDataForEntitiesCreator(_dbContext).Create();
    }
}
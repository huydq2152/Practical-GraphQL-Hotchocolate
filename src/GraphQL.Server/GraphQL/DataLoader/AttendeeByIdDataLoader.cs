using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.DataLoader;

public class AttendeeByIdDataLoader : BatchDataLoader<int, Attendee>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public AttendeeByIdDataLoader(IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> dbContextFactory, DataLoaderOptions? options = null) : base(
        batchScheduler, options)
    {
        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Attendee>> LoadBatchAsync(IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Attendees
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, cancellationToken);
    }
}
﻿using GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.DataLoader;

public class SpeakerByIdDataLoader: BatchDataLoader<int, Data.Entities.Speaker>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public SpeakerByIdDataLoader(
        IBatchScheduler batchScheduler, 
        IDbContextFactory<ApplicationDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory ?? 
                            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Data.Entities.Speaker>> LoadBatchAsync(
        IReadOnlyList<int> keys, 
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext = 
            await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Speakers
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
﻿using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.DataLoader;

public class SessionByIdDataLoader: BatchDataLoader<int, Session>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public SessionByIdDataLoader(
        IBatchScheduler batchScheduler, 
        IDbContextFactory<ApplicationDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory ?? 
                            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
        IReadOnlyList<int> keys, 
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext = 
            await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            
        return await dbContext.Sessions
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
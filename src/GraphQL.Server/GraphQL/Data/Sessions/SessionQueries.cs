using GraphQL.Server.Data;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Sessions;

[ExtendObjectType("Query")]
public class SessionQueries
{
    [UsePaging(typeof(NonNullType<SessionType>))]
    [UseFiltering(typeof(SessionFilterInputType))]
    [UseSorting]
    public Task<IQueryable<Session>> GetPagedSessionsAsync(
        ApplicationDbContext context) =>
        Task.FromResult<IQueryable<Session>>(context.Sessions);

    public async Task<IEnumerable<Session>> GetSessionsAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Sessions.ToListAsync(cancellationToken);

    public Task<Session> GetSessionByIdAsync(
        [ID(nameof(Session))] int id,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        sessionById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
        [ID(nameof(Session))] int[] ids,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        await sessionById.LoadAsync(ids, cancellationToken);
}
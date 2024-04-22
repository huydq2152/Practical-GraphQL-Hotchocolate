using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using GraphQL.GraphQL.Model.Sessions;
using GraphQL.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Queries;

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
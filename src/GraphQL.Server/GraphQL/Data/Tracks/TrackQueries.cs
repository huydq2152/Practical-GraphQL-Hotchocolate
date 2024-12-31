using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Tracks;

[ExtendObjectType("Query")]
public class TrackQueries
{
    [UsePaging]
    public Task<IQueryable<Track>> GetPagedTracksAsync(
        ApplicationDbContext context) =>
        Task.FromResult<IQueryable<Track>>(context.Tracks.OrderBy(t => t.Name));

    public async Task<IEnumerable<Track>> GetTracksAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Tracks.ToListAsync(cancellationToken);

    public Task<Track> GetTrackByNameAsync(
        string name,
        ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        context.Tracks.FirstAsync(t => t.Name == name, cancellationToken);

    public async Task<IEnumerable<Track>> GetTrackByNamesAsync(
        string[] names,
        ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Tracks.Where(t => names.Contains(t.Name)).ToListAsync(cancellationToken);

    public Task<Track> GetTrackByIdAsync(
        [ID(nameof(Track))] int id,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken) =>
        trackById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Track>> GetTracksByIdAsync(
        [ID(nameof(Track))] int[] ids,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken) =>
        await trackById.LoadAsync(ids, cancellationToken);
}
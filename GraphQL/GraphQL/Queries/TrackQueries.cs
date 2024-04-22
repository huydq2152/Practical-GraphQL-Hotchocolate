﻿using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using GraphQL.GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Queries;

[ExtendObjectType("Query")]
public class TrackQueries
{
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
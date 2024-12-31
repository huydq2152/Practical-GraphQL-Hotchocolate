using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Data.Sessions;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Tracks;

public class TrackType : ObjectType<Track>
{
    protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) =>
                ctx.DataLoader<TrackByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.Sessions)
            .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
            .UsePaging<NonNullType<SessionType>>()
            .Name("sessions");

        // descriptor.Field(t => t.Name).UseUpperCase(); // use UseUpperCaseAttribute instead
    }

    private class TrackResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            [Parent] Track track,
            ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            var sessionIds = await dbContext.Sessions
                .Where(s => s.Id == track.Id)
                .Select(s => s.Id)
                .ToArrayAsync(cancellationToken);

            return await sessionById.LoadAsync(sessionIds, cancellationToken);
        }
    }
}
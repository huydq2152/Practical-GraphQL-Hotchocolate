using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using GraphQL.GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Types;

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
            .Name("sessions");

        // descriptor.Field(t => t.Name).UseUpperCase(); // use UseUpperCaseAttribute instead
    }

    private class TrackResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            Track track,
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
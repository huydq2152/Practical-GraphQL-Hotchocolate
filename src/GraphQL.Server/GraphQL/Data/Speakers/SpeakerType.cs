using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Data.Sessions;
using GraphQL.Server.GraphQL.DataLoader;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Speakers;

public class SpeakerType : ObjectType<Speaker>
{
    protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
    {
        descriptor.Authorize();

        // Follow the Relay specification, configures the type to implement the Node interface, use Id as the identifier, and use DataLoader to load objects by ID. 
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) => ctx.DataLoader<SpeakerByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.SessionSpeakers)
            .Description("The sessions that the speaker is presenting.")
            .Name("sessions")
            .UsePaging(
                connectionName: "SpeakerSessions",
                options: new PagingOptions
                {
                    IncludeTotalCount = true,
                    MaxPageSize = 200,
                    DefaultPageSize = 100
                }
            )
            .UseFiltering(typeof(SessionFilterInputType))
            .UseSorting(typeof(SessionSortInputType))
            .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default));
    }

    private class SpeakerResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            [Parent] Speaker speaker,
            ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] sessionIds = await dbContext.Speakers
                .Where(s => s.Id == speaker.Id)
                .Include(s => s.SessionSpeakers)
                .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                .ToArrayAsync(cancellationToken);

            return await sessionById.LoadAsync(sessionIds, cancellationToken);
        }
    }
}
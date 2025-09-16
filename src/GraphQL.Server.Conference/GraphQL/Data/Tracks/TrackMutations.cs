using GraphQL.Server.Conference.Data.Contexts;
using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;
using GraphQL.Server.Conference.GraphQL.Data.Tracks.Add;
using GraphQL.Server.Conference.GraphQL.Data.Tracks.Rename;
using GraphQL.Server.Conference.Data;

namespace GraphQL.Server.Conference.GraphQL.Data.Tracks;

[ExtendObjectType("Mutation")]
public class TrackMutations
{
    public async Task<AddTrackPayload> AddTrackAsync(
        AddTrackInput input, ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var track = new Track { Name = input.Name };
        context.Tracks.Add(track);

        await context.SaveChangesAsync(cancellationToken);

        return new AddTrackPayload(track);
    }

    public async Task<RenameTrackPayload> RenameTrackAsync(
        RenameTrackInput input, ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var track = await context.Tracks.FindAsync(input.Id);
        if (track == null)
        {
            return new RenameTrackPayload(
                new List<UserError>()
                {
                    new($"Track does not exist with Id = {track}.", "400")
                });
        }

        track.Name = input.Name;

        await context.SaveChangesAsync(cancellationToken);

        return new RenameTrackPayload(track);
    }
}
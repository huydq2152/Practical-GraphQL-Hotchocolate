using GraphQL.Server.Data;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Sessions.Schedule;

public class ScheduleSessionPayload : SessionPayloadBase
{
    public ScheduleSessionPayload(Session session)
        : base(session)
    {
    }

    public ScheduleSessionPayload(UserError error)
        : base(new[] { error })
    {
    }

    public async Task<Track?> GetTrackAsync(
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken)
    {
        if (Session is null)
        {
            return null;
        }

        return await trackById.LoadAsync(Session.Id, cancellationToken);
    }

    public async Task<IEnumerable<Speaker>?> GetSpeakersAsync(
        ApplicationDbContext dbContext,
        SpeakerByIdDataLoader speakerById,
        CancellationToken cancellationToken)
    {
        if (Session is null)
        {
            return null;
        }

        var speakerIds = await dbContext.Sessions
            .Where(s => s.Id == Session.Id)
            .Include(s => s.SessionSpeakers)
            .SelectMany(s => s.SessionSpeakers.Select(t => t.SpeakerId))
            .ToArrayAsync(cancellationToken);

        return await speakerById.LoadAsync(speakerIds, cancellationToken);
    }
}
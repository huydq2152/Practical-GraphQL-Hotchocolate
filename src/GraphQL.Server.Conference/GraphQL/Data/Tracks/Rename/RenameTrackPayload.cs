using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Tracks.Rename;

public class RenameTrackPayload: TrackPayloadBase
{
    public RenameTrackPayload(Track track) 
        : base(track)
    {
    }

    public RenameTrackPayload(IReadOnlyList<UserError> errors) 
        : base(errors)
    {
    }
}
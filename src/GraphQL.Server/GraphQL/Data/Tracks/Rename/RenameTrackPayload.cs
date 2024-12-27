using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Tracks.Rename;

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
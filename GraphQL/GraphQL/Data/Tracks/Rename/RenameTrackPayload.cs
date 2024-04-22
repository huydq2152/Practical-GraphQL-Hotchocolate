using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Tracks.Rename;

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
using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Tracks.Add;

public class AddTrackPayload: TrackPayloadBase
{
    public AddTrackPayload(Track track) 
        : base(track)
    {
    }

    public AddTrackPayload(IReadOnlyList<UserError> errors) 
        : base(errors)
    {
    }
}
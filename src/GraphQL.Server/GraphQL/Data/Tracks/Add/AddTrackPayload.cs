using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Tracks.Add;

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
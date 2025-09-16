using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Tracks.Add;

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
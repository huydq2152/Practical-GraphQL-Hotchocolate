using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Tracks;

public class TrackPayloadBase: Payload
{
    public TrackPayloadBase(Track track)
    {
        Track = track;
    }

    public TrackPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Track? Track { get; }
}
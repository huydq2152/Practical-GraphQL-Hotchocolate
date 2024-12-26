using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Tracks;

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
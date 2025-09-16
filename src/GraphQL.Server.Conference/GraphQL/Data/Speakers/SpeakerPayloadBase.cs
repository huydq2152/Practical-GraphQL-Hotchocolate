using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Speakers;

public class SpeakerPayloadBase: Payload
{
    protected SpeakerPayloadBase(Speaker speaker)
    {
        Speaker = speaker;
    }

    protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Speaker? Speaker { get; }
}
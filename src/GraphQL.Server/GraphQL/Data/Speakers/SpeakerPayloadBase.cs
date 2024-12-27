using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Speakers;

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
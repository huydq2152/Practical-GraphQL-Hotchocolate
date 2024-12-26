using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Speakers.Add;

public class AddSpeakerPayload : SpeakerPayloadBase
{
    public AddSpeakerPayload(Speaker speaker) : base(speaker)
    {
    }

    public AddSpeakerPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
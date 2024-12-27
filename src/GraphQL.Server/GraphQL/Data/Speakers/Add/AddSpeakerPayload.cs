using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Speakers.Add;

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
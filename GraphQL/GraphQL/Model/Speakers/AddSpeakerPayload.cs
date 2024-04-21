using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Model.Speakers;

public class AddSpeakerPayload : SpeakerPayloadBase
{
    public AddSpeakerPayload(Data.Entities.Speaker speaker) : base(speaker)
    {
    }

    public AddSpeakerPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Speakers.Add;

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
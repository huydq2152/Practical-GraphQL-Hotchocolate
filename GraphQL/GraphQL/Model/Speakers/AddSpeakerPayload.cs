namespace GraphQL.GraphQL.Model.Speakers;

public class AddSpeakerPayload
{
    public AddSpeakerPayload(Data.Entities.Speaker speaker)
    {
        Speaker = speaker;
    }

    public Data.Entities.Speaker Speaker { get; }
}
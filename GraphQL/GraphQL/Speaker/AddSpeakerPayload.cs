namespace GraphQL.GraphQL.Speaker;

public class AddSpeakerPayload
{
    public AddSpeakerPayload(Data.Speaker speaker)
    {
        Speaker = speaker;
    }

    public Data.Speaker Speaker { get; }
}
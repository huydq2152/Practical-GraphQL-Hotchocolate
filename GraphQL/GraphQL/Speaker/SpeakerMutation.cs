using GraphQL.Data;

namespace GraphQL.GraphQL.Speaker;

public class SpeakerMutation
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [Service] ApplicationDbContext context)
    {
        var speaker = new Data.Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}
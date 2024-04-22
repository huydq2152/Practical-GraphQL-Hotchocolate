using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.Data.Speakers.Add;

namespace GraphQL.GraphQL.Data.Speakers;

[ExtendObjectType("Mutation")]
public class SpeakerMutations
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        ApplicationDbContext context)
    {
        var speaker = new Speaker
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
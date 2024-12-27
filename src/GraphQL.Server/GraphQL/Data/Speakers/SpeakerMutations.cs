using GraphQL.Server.Data;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Data.Speakers.Add;

namespace GraphQL.Server.GraphQL.Data.Speakers;

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
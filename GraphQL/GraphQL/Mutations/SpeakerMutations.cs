using GraphQL.Data;
using GraphQL.GraphQL.Model.Speakers;
using GraphQL.GraphQL.Model.Speakers.Add;

namespace GraphQL.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class SpeakerMutations
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        ApplicationDbContext context)
    {
        var speaker = new Data.Entities.Speaker
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
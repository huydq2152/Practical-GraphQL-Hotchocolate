using GraphQL.Data;

namespace GraphQL.GraphQL.Speaker;

public class SpeakerQuery
{
    public IQueryable<Data.Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
        context.Speakers;
}
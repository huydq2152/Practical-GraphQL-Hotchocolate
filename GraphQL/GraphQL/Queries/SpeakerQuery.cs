using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Queries;

public class SpeakerQuery
{
    public Task<List<Speaker>> GetSpeakers(ApplicationDbContext context) =>
        context.Speakers.ToListAsync();
    public Task<Speaker> GetSpeakerAsync(
        int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}
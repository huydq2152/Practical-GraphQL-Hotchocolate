using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.GraphQL.Queries;

[ExtendObjectType("Query")]
public class SpeakerQuery
{
    public Task<List<Speaker>> GetSpeakers(ApplicationDbContext context) =>
        context.Speakers.ToListAsync();
    public Task<Speaker> GetSpeakerAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}
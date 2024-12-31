using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Speakers;

[ExtendObjectType("Query")]
public class SpeakerQueries
{
    [UsePaging]
    public Task<IQueryable<Speaker>> GetPagedSpeakersAsync(
        ApplicationDbContext context) =>
        Task.FromResult<IQueryable<Speaker>>(context.Speakers.OrderBy(t => t.Name));
    
    public Task<List<Speaker>> GetSpeakersAsync(ApplicationDbContext context) =>
        context.Speakers.ToListAsync();
    
    public async Task<Speaker> GetSpeakerByIdAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        await dataLoader.LoadAsync(id, cancellationToken);
    
    public async Task<IEnumerable<Speaker>> GetSpeakersByIdsAsync(
        [ID(nameof(Speaker))]int[] ids,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        await dataLoader.LoadAsync(ids, cancellationToken);
}
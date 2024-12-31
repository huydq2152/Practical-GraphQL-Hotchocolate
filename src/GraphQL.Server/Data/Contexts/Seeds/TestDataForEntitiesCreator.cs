using GraphQL.Server.Data.Entities;

namespace GraphQL.Server.Data.Contexts.Seeds;

public class TestDataForEntitiesCreator
{
    private readonly ApplicationDbContext _dbContext;

    public TestDataForEntitiesCreator(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create()
    {
        await CreateTestDataForEntities();
    }

    private async Task CreateTestDataForEntities()
    {
        await CreateTestDataForSpeaker();
        await CreateTestDataForSession();
        await CreateTestDataForSessionSpeaker();
    }

    private async Task CreateTestDataForSpeaker()
    {
        var speakers = new List<Speaker>();
        for (var i = 1; i < 15; i++)
        {
            speakers.Add(new Speaker()
            {
                Name = $"Name of speaker number {i}",
                Bio = $"Bio number {i}",
                WebSite = $"Website number {i}"
            });
        }
        if (!_dbContext.Set<Speaker>().Any())
        {
            await _dbContext.Set<Speaker>().AddRangeAsync(speakers);
        }

        await _dbContext.SaveChangesAsync();
    }
    
    private async Task CreateTestDataForSession()
    {
        var sessions = new List<Session>();
        for (var i = 1; i < 15; i++)
        {
            sessions.Add(new Session()
            {
                Title = $"Title of session number {i}",
                Abstract = $"Abstract number {i}",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            });
        }
        if (!_dbContext.Set<Session>().Any())
        {
            await _dbContext.Set<Session>().AddRangeAsync(sessions);
        }

        await _dbContext.SaveChangesAsync();
    }
    
    private async Task CreateTestDataForSessionSpeaker()
    {
        var sessionSpeakers = new List<SessionSpeaker>();
        for (var i = 1; i < 15; i++)
        {
            sessionSpeakers.Add(new SessionSpeaker()
            {
                SpeakerId = i,
                SessionId = i
            });
        }
        if (!_dbContext.Set<SessionSpeaker>().Any())
        {
            await _dbContext.Set<SessionSpeaker>().AddRangeAsync(sessionSpeakers);
        }

        await _dbContext.SaveChangesAsync();
    }
}
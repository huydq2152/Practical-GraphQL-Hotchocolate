using GraphQL.Server.Conference.Data.Contexts;
using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.DataLoader;
using GraphQL.Server.Conference.GraphQL.Extensions;
using GraphQL.Server.Conference.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.Conference.GraphQL.Data.Sessions.CheckIn;

public class SessionAttendeeCheckIn
{
    public SessionAttendeeCheckIn(int attendeeId, int sessionId)
    {
        AttendeeId = attendeeId;
        SessionId = sessionId;
    }

    [ID(nameof(Attendee))] public int AttendeeId { get; }
    [ID(nameof(Session))] public int SessionId { get; }

    public async Task<int> CheckInCountAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Sessions
            .Where(session => session.Id == SessionId)
            .SelectMany(session => session.SessionAttendees)
            .CountAsync(cancellationToken);

    public Task<Attendee> GetAttendeeAsync(
        AttendeeByIdDataLoader attendeeById,
        CancellationToken cancellationToken) =>
        attendeeById.LoadAsync(AttendeeId, cancellationToken);

    public Task<Session> GetSessionAsync(
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        sessionById.LoadAsync(SessionId, cancellationToken);
}
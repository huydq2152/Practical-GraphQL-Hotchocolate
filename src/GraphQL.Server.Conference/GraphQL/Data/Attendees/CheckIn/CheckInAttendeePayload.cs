using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;
using GraphQL.Server.Conference.GraphQL.DataLoader;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees.CheckIn;

public class CheckInAttendeePayload: AttendeePayloadBase
{
    private int? _sessionId;

    public CheckInAttendeePayload(Attendee attendee, int sessionId)
        : base(attendee)
    {
        _sessionId = sessionId;
    }

    public CheckInAttendeePayload(UserError error)
        : base(new[] { error })
    {
    }

    public async Task<Session?> GetSessionAsync(
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken)
    {
        if (_sessionId.HasValue)
        {
            return await sessionById.LoadAsync(_sessionId.Value, cancellationToken);
        }

        return null;
    }
}
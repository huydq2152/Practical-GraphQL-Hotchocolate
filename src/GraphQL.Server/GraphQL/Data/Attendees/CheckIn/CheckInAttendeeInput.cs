using GraphQL.Server.Data.Entities;

namespace GraphQL.Server.GraphQL.Data.Attendees.CheckIn;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Attendee))]
    int AttendeeId);
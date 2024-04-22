using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Data.Attendees.CheckIn;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Attendee))]
    int AttendeeId);
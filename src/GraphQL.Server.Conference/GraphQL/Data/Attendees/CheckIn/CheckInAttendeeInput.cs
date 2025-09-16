using GraphQL.Server.Conference.Data.Entities;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees.CheckIn;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Attendee))]
    int AttendeeId);
using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Model.Attendees.CheckIn;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Attendee))]
    int AttendeeId);
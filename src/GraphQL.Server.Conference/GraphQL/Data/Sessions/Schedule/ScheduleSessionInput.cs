using GraphQL.Server.Conference.Data.Entities;

namespace GraphQL.Server.Conference.GraphQL.Data.Sessions.Schedule;

public record ScheduleSessionInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Track))]
    int TrackId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
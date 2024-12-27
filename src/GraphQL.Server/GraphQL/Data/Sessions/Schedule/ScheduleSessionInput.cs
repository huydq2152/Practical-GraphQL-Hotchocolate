using GraphQL.Server.Data.Entities;

namespace GraphQL.Server.GraphQL.Data.Sessions.Schedule;

public record ScheduleSessionInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Track))]
    int TrackId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
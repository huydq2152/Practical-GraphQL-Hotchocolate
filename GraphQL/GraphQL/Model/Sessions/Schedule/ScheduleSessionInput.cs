using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Model.Sessions.Schedule;

public record ScheduleSessionInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Track))]
    int TrackId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
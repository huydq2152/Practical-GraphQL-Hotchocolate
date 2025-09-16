using GraphQL.Server.Conference.Data.Entities;

namespace GraphQL.Server.Conference.GraphQL.Data.Sessions.Add;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
    IReadOnlyList<int> SpeakerIds);
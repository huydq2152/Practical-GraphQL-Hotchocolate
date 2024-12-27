using GraphQL.Server.Data.Entities;

namespace GraphQL.Server.GraphQL.Data.Sessions.Add;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
    IReadOnlyList<int> SpeakerIds);
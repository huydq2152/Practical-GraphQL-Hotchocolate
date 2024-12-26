using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Data.Sessions.Add;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
    IReadOnlyList<int> SpeakerIds);
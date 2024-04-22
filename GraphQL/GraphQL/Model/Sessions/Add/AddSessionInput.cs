using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Model.Sessions.Add;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
    IReadOnlyList<int> SpeakerIds);
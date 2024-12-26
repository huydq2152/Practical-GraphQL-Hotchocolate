using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Data.Tracks.Rename;

public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
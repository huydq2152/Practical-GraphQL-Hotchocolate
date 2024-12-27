using GraphQL.Server.Data.Entities;

namespace GraphQL.Server.GraphQL.Data.Tracks.Rename;

public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
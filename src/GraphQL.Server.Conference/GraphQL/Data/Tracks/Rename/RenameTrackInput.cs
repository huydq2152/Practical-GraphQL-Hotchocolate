using GraphQL.Server.Conference.Data.Entities;

namespace GraphQL.Server.Conference.GraphQL.Data.Tracks.Rename;

public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
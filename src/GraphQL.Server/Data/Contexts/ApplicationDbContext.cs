﻿using GraphQL.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Attendee>()
            .HasIndex(a => a.UserName)
            .IsUnique();

        // Many-to-many: Session <-> Attendee
        modelBuilder
            .Entity<SessionAttendee>()
            .HasKey(ca => new { ca.SessionId, ca.AttendeeId });

        // Many-to-many: Speaker <-> Session
        modelBuilder
            .Entity<SessionSpeaker>()
            .HasKey(ss => new { ss.SessionId, ss.SpeakerId });
    }

    public DbSet<Speaker> Speakers { get; set; } = default!;
    public DbSet<Session> Sessions { get; set; } = default!;
    public DbSet<Track> Tracks { get; set; } = default!;
    public DbSet<Attendee> Attendees { get; set; } = default!;
}
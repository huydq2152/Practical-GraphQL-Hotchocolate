﻿using GraphQL.Server.Data;
using GraphQL.Server.Data.Contexts;
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.GraphQL.Data.Sessions;

public class SessionType : ObjectType<Session>
{
    protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) => ctx.DataLoader<SessionByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.SessionSpeakers)
            .ResolveWith<SessionResolvers>(t => t.GetSpeakersAsync(default!, default!, default!, default))
            .Name("speakers");

        descriptor
            .Field(t => t.SessionAttendees)
            .ResolveWith<SessionResolvers>(t => t.GetAttendeesAsync(default!, default!, default!, default))
            .Name("attendees");

        descriptor
            .Field(t => t.Track)
            .ResolveWith<SessionResolvers>(t => t.GetTrackAsync(default!, default!, default));

        descriptor
            .Field(t => t.TrackId)
            .ID(nameof(Track));
    }

    private class SessionResolvers
    {
        public async Task<IEnumerable<Speaker>> GetSpeakersAsync(
            Session session,
            ApplicationDbContext dbContext,
            SpeakerByIdDataLoader speakerById,
            CancellationToken cancellationToken)
        {
            var speakerIds = await dbContext.Sessions
                .Where(s => s.Id == session.Id)
                .Include(s => s.SessionSpeakers)
                .SelectMany(s => s.SessionSpeakers.Select(t => t.SpeakerId))
                .ToArrayAsync(cancellationToken);

            return await speakerById.LoadAsync(speakerIds, cancellationToken);
        }

        public async Task<IEnumerable<Attendee>> GetAttendeesAsync(
            Session session,
            ApplicationDbContext dbContext,
            AttendeeByIdDataLoader attendeeById,
            CancellationToken cancellationToken)
        {
            var attendeeIds = await dbContext.Sessions
                .Where(s => s.Id == session.Id)
                .Include(session => session.SessionAttendees)
                .SelectMany(session => session.SessionAttendees.Select(t => t.AttendeeId))
                .ToArrayAsync(cancellationToken);

            return await attendeeById.LoadAsync(attendeeIds, cancellationToken);
        }

        public async Task<Track?> GetTrackAsync(
            Session session,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            if (session.TrackId is null)
            {
                return null;
            }

            return await trackById.LoadAsync(session.TrackId.Value, cancellationToken);
        }
    }
}
using GraphQL.Server.Conference.Data.Contexts;
using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;
using GraphQL.Server.Conference.GraphQL.Data.Attendees.CheckIn;
using GraphQL.Server.Conference.GraphQL.Data.Attendees.Register;
using GraphQL.Server.Conference.Data;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees;

[ExtendObjectType(Name = "Mutation")]
public class AttendeeMutations
{
    public async Task<RegisterAttendeePayload> RegisterAttendeeAsync(
        RegisterAttendeeInput input,
        ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var attendee = new Attendee
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            UserName = input.UserName,
            EmailAddress = input.EmailAddress
        };

        context.Attendees.Add(attendee);

        await context.SaveChangesAsync(cancellationToken);

        return new RegisterAttendeePayload(attendee);
    }
    
    public async Task<CheckInAttendeePayload> CheckInAttendeeAsync(
        CheckInAttendeeInput input,
        ApplicationDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var attendee = await context.Attendees.FirstOrDefaultAsync(
            t => t.Id == input.AttendeeId, cancellationToken);

        if (attendee is null)
        {
            return new CheckInAttendeePayload(
                new UserError("Attendee not found.", "ATTENDEE_NOT_FOUND"));
        }

        attendee.SessionsAttendees.Add(
            new SessionAttendee
            {
                SessionId = input.SessionId
            });

        await context.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(
            "OnAttendeeCheckedIn_" + input.SessionId,
            input.AttendeeId,
            cancellationToken);

        return new CheckInAttendeePayload(attendee, input.SessionId);
    }
}
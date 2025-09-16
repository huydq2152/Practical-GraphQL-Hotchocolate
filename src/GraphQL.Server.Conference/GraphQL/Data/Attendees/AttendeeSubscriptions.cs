using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Data.Sessions.CheckIn;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees;

[ExtendObjectType(Name = "Subscription")]
public class AttendeeSubscriptions
{
    [Subscribe(With = nameof(SubscribeToOnAttendeeCheckedInAsync))]
    public SessionAttendeeCheckIn OnAttendeeCheckedIn(
        [ID(nameof(Session))] int sessionId,
        [EventMessage] int attendeeId) =>
        new SessionAttendeeCheckIn(attendeeId, sessionId);

    public async Task<ISourceStream<string>> SubscribeToOnAttendeeCheckedInAsync(
        int sessionId,
        [Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken) =>
        await eventReceiver.SubscribeAsync<string>(
            "OnAttendeeCheckedIn_" + sessionId, cancellationToken);
}
using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.DataLoader;

namespace GraphQL.Server.Conference.GraphQL.Data.Sessions;

[ExtendObjectType(Name = "Subscription")]
public class SessionSubscriptions
{
    [Subscribe]
    [Topic]
    public Task<Session> OnSessionScheduledAsync(
        [EventMessage] int sessionId,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken) =>
        sessionById.LoadAsync(sessionId, cancellationToken);
}
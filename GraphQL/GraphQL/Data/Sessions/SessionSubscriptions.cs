using GraphQL.Data.Entities;
using GraphQL.GraphQL.DataLoader;

namespace GraphQL.GraphQL.Data.Sessions;

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
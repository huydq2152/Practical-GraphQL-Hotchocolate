using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.DataLoader;

namespace GraphQL.Server.GraphQL.Data.Sessions;

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
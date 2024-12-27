using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Sessions;

public class SessionPayloadBase: Payload
{
    protected SessionPayloadBase(Session session)
    {
        Session = session;
    }

    protected SessionPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Session? Session { get; }
}
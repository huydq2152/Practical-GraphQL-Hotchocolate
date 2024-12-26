using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Sessions;

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
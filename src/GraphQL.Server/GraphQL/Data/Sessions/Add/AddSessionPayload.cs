using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Sessions.Add;

public class AddSessionPayload: SessionPayloadBase
{
    public AddSessionPayload(UserError error)
        : base(new[] { error })
    {
    }

    public AddSessionPayload(Session session) : base(session)
    {
    }

    public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
}
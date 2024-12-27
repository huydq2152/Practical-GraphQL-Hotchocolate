using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Attendees;

public class AttendeePayloadBase: Payload
{
    protected AttendeePayloadBase(Attendee attendee)
    {
        Attendee = attendee;
    }

    protected AttendeePayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Attendee? Attendee { get; }
}
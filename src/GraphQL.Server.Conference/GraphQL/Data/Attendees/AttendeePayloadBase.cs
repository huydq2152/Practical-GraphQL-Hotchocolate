using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees;

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
using GraphQL.Server.Data.Entities;
using GraphQL.Server.GraphQL.Common;

namespace GraphQL.Server.GraphQL.Data.Attendees.Register;

public class RegisterAttendeePayload : AttendeePayloadBase
{
    public RegisterAttendeePayload(Attendee attendee)
        : base(attendee)
    {
    }

    public RegisterAttendeePayload(UserError error)
        : base(new[] { error })
    {
    }
}
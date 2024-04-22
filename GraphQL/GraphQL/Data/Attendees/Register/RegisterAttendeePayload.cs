using GraphQL.Data.Entities;
using GraphQL.GraphQL.Common;

namespace GraphQL.GraphQL.Data.Attendees.Register;

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
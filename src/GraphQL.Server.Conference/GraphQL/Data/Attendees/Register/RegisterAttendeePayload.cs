using GraphQL.Server.Conference.Data.Entities;
using GraphQL.Server.Conference.GraphQL.Common;

namespace GraphQL.Server.Conference.GraphQL.Data.Attendees.Register;

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
namespace GraphQL.GraphQL.Model.Attendees.Register;

public record RegisterAttendeeInput(
    string FirstName,
    string LastName,
    string UserName,
    string EmailAddress);
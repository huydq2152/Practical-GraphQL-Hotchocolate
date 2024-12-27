namespace GraphQL.Client.WebApi.DTOs.Common;

public class UserError
{
    public UserError(string message, string code)
    {
        Message = message;
        Code = code;
    }

    public string Message { get; }

    public string Code { get; }
}
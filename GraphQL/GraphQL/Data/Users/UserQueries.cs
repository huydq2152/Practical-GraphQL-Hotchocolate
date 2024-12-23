using System.Security.Claims;
using GraphQL.Data.Entities;

namespace GraphQL.GraphQL.Data.Users;

[ExtendObjectType("Query")]
public class UserQueries
{
    public User GetMe(ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var user = GetUserFromSeedDatabase(userId);

        return user;
    }
    
    private User GetUserFromSeedDatabase(string userId)
    {
        return new User { Id = userId, Name = "Tên Người Dùng", Email = "email@example.com" };
    }
}
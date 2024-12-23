using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GraphQL.Extensions.ServiceExtensions;

public static class AuthExtensions
{
    public static IServiceCollection RegisterAuthenticationScheme(this IServiceCollection services)
    {
        var signingKey = new SymmetricSecurityKey("MySuperSecretKey"u8.ToArray());

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidIssuer = "https://auth.chillicream.com",
                        ValidAudience = "https://graphql.chillicream.com",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey
                    };
            });
        
        return services;
    }
}
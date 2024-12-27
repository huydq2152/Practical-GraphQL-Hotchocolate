using GraphQL.Client.WebApi.Configurations.Auths;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Client.WebApi.Extensions.ServiceExtensions;

public static class AuthExtensions
{
    public static IServiceCollection RegisterAzureAdConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<AzureAdConfig>()
            .Bind(configuration.GetSection("AzureAd"));
        return services;
    }
}
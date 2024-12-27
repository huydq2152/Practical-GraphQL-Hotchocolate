using System;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL.Client.WebApi.Configurations.Auths;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GraphQL.Client.WebApi.Extensions.ServiceExtensions;

public static class GraphQlExtensions
{
    public static IServiceCollection RegisterGraphQLClient(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IGraphQLClient>(sp =>
            new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(configuration["GraphQLURI"]),
                HttpMessageHandler = new AuthorizationHandler(sp.GetRequiredService<IOptions<AzureAdConfig>>()),
            }, new SystemTextJsonSerializer())
        );
        return services;
    }
}
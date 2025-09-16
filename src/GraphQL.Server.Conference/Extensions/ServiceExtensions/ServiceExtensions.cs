using GraphQL.Server.Conference.Data.Contexts.Seeds;
using GraphQL.Server.Conference.GraphQL.Configurations;

namespace GraphQL.Server.Conference.Extensions.ServiceExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConfiguration(configuration);
        services.AddScoped<ApplicationContextSeed>();
        
        return services;
    }
    
    private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ClientIdMaxPageSizeOptions>(configuration.GetSection("ClientIdMaxPageSizes"));
        
        return services;
    }
}
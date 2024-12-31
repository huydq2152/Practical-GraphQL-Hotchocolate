using GraphQL.Server.Data.Contexts.Seeds;

namespace GraphQL.Server.Extensions.ServiceExtensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContextSeed>();
        
        return services;
    }
}
using GraphQL.Server.Data;
using GraphQL.Server.GraphQL.Data.Attendees;
using GraphQL.Server.GraphQL.Data.Sessions;
using GraphQL.Server.GraphQL.Data.Speakers;
using GraphQL.Server.GraphQL.Data.Tracks;
using GraphQL.Server.GraphQL.DataLoader;

namespace GraphQL.Server.Extensions.ServiceExtensions;

public static class GraphQlExtensions
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            
            .AddAuthorization() // Only exposes the identity of the authenticated user to our application through a ClaimsPrincipal
            
            .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SpeakerQueries>()
            .AddTypeExtension<SessionQueries>()
            .AddTypeExtension<TrackQueries>()
            .AddTypeExtension<AttendeeQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<SpeakerMutations>()
            .AddTypeExtension<SessionMutations>()
            .AddTypeExtension<TrackMutations>()
            .AddTypeExtension<AttendeeMutations>()
            .AddSubscriptionType(d => d.Name("Subscription"))
            .AddTypeExtension<SessionSubscriptions>()
            .AddTypeExtension<AttendeeSubscriptions>()
            .AddType<AttendeeType>()
            .AddType<SessionType>()
            .AddType<SpeakerType>()
            .AddType<TrackType>()
            .AddGlobalObjectIdentification()
            // .AddQueryFieldToMutationPayloads()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions()
            .AddDataLoader<SpeakerByIdDataLoader>()
            .AddDataLoader<SessionByIdDataLoader>()
            .AddDataLoader<AttendeeByIdDataLoader>()
            .AddDataLoader<TrackByIdDataLoader>();

        return services;
    }
}
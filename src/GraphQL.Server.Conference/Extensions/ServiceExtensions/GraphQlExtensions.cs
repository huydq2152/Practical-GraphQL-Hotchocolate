using GraphQL.Server.Conference.Data.Contexts;
using GraphQL.Server.Conference.GraphQL.Data.Attendees;
using GraphQL.Server.Conference.GraphQL.Data.Sessions;
using GraphQL.Server.Conference.GraphQL.Data.Speakers;
using GraphQL.Server.Conference.GraphQL.Data.Tracks;
using GraphQL.Server.Conference.GraphQL.DataLoader;

namespace GraphQL.Server.Conference.Extensions.ServiceExtensions;

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
using GraphQL.Data;
using GraphQL.GraphQL.Data.Attendees;
using GraphQL.GraphQL.Data.Sessions;
using GraphQL.GraphQL.Data.Speakers;
using GraphQL.GraphQL.Data.Tracks;
using GraphQL.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    
    .AddQueryType(d=> d.Name("Query"))
    .AddTypeExtension<SpeakerQueries>()
    .AddTypeExtension<SessionQueries>()
    .AddTypeExtension<TrackQueries>()
    .AddTypeExtension<AttendeeQueries>()
    
    .AddMutationType(d=> d.Name("Mutation"))
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


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseWebSockets();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.Run();
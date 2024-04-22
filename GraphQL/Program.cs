using GraphQL.Data;
using GraphQL.GraphQL.DataLoader;
using GraphQL.GraphQL.Mutations;
using GraphQL.GraphQL.Queries;
using GraphQL.GraphQL.Types;
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

    .AddType<AttendeeType>()
    .AddType<SessionType>()
    .AddType<SpeakerType>()
    .AddType<TrackType>()
    
    .AddGlobalObjectIdentification()
    // .AddQueryFieldToMutationPayloads()
    
    .AddFiltering()
    .AddSorting()
    
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>()
    .AddDataLoader<AttendeeByIdDataLoader>()
    .AddDataLoader<TrackByIdDataLoader>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.Run();
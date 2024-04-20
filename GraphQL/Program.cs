using GraphQL.Data;
using GraphQL.GraphQL.Speaker;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<SpeakerQuery>()
    .AddMutationType<SpeakerMutation>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.Run();
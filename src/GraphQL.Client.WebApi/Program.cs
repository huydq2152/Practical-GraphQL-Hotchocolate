using GraphQL.Client.WebApi.Extensions.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL.Server.Conference.Client", Version = "v1" });
});

builder.Services.RegisterAzureAdConfig(builder.Configuration)
    .RegisterGraphQLClient(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL.Server.Conference.Client v1"));
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
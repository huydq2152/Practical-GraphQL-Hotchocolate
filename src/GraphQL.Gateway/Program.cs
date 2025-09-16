using GraphQL.Gateway.HttpHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ForwardRequestHttpClientHandler>();

builder.Services.AddHttpClient("Fusion")
    .AddHttpMessageHandler<ForwardRequestHttpClientHandler>();;

builder.Services
    .AddFusionGatewayServer()
    .ConfigureFromFile("gateway.fgp")
    // Note: AllowQueryPlan is enabled for demonstration purposes. Disable in production environments.
    .ModifyFusionOptions(x => x.AllowQueryPlan = true);

var app = builder.Build();

app.MapGraphQL();

app.Run();
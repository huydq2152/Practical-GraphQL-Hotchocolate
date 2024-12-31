using System.Security.Claims;
using GraphQL.Server.GraphQL.Configurations;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.Extensions.Options;

namespace GraphQL.Server.GraphQL.Middlewares;

public class DynamicMaxPageSizeMiddleware
{
    private readonly FieldDelegate _next;
    private readonly IOptions<ClientIdMaxPageSizeOptions> _clientIdMaxPageSizeOptions;

    public DynamicMaxPageSizeMiddleware(FieldDelegate next, IOptions<ClientIdMaxPageSizeOptions> clientIdMaxPageSizeOptions)
    {
        _next = next;
        _clientIdMaxPageSizeOptions = clientIdMaxPageSizeOptions;
    }

    public async Task InvokeAsync(IMiddlewareContext context)
    {
        var user = context.ContextData["ClaimsPrincipal"] as ClaimsPrincipal;
        var clientId = user?.FindFirstValue("appid");

        if (!string.IsNullOrEmpty(clientId))
        {
            var maxPageSize = GetMaxPageSizeForClient(clientId);
            
            var firstArgument = context.ArgumentValue<int?>("first");
            if (firstArgument.HasValue && firstArgument > maxPageSize)
            {
                context.ReportError(ErrorBuilder.New().SetMessage($"argument 'first' exceeds the maximum allowed value of maxPageSize: {maxPageSize}.").Build());
            }
            
            var lastArgument = context.ArgumentValue<int?>("last");
            if (lastArgument.HasValue && lastArgument > maxPageSize)
            {
                context.ReportError(ErrorBuilder.New().SetMessage($"argument 'last' argument exceeds the maximum allowed value of maxPageSize: {maxPageSize}.").Build());
            }
        }
        
        await _next(context);
    }

    private int GetMaxPageSizeForClient(string clientId)
    {
        var maxPageSizes = _clientIdMaxPageSizeOptions.Value.MaxPageSizes;
        
        if (maxPageSizes.TryGetValue(clientId, out var maxPageSize))
        {
            return maxPageSize;
        }

        return maxPageSizes.GetValueOrDefault("default", 200);
    }
}
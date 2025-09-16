namespace GraphQL.Gateway.HttpHandlers;

public class ForwardRequestHttpClientHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ??
                                                                 throw new ArgumentNullException(
                                                                     nameof(httpContextAccessor));

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine($"Request Content: {content}");
        }
        
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is not null &&
            httpContext.Request.Headers.TryGetValue("Authorization", out var authHeaderValue))
        {
            request.Headers.TryAddWithoutValidation("Authorization", authHeaderValue.ToString());
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
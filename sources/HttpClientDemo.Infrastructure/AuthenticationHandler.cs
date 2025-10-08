using System.Net.Http.Headers;

namespace HttpClientDemo.Infrastructure;

public class AuthenticationHandler : DelegatingHandler
{
    public AuthenticationHandler()
    {
    }

    public AuthenticationHandler(HttpMessageHandler httpMessageHandler)
        : base(httpMessageHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string token = "token";
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}

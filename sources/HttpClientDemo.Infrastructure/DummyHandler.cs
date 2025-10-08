namespace HttpClientDemo.Infrastructure;

public class DummyHandler : DelegatingHandler
{
    public DummyHandler()
    {
    }

    public DummyHandler(HttpMessageHandler httpMessageHandler)
        : base(httpMessageHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Dummy", "dummy");

        return await base.SendAsync(request, cancellationToken);
    }
}

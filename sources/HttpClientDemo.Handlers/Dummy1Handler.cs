namespace DustInTheWind.HttpClientDemo.Handlers;

public class Dummy1Handler : DelegatingHandler
{
    public Dummy1Handler()
    {
    }

    public Dummy1Handler(HttpMessageHandler httpMessageHandler)
        : base(httpMessageHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Dummy1", "value1");

        return await base.SendAsync(request, cancellationToken);
    }
}

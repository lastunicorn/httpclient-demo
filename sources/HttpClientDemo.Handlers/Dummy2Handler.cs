namespace DustInTheWind.HttpClientDemo.Handlers;

public class Dummy2Handler : DelegatingHandler
{
    public Dummy2Handler()
    {
    }

    public Dummy2Handler(HttpMessageHandler httpMessageHandler)
        : base(httpMessageHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Dummy2", "value2");

        return await base.SendAsync(request, cancellationToken);
    }
}

namespace DustInTheWind.HttpClientWithMessageHandlersDemo.Common;

public sealed class WebApiClient : IDisposable
{
    private readonly HttpClient httpClient;

    public WebApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task GetDemo(CancellationToken cancellationToken)
    {
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("Demo", cancellationToken);

        Console.WriteLine("StatusCode: " + httpResponseMessage.StatusCode);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine(content);
        }
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}

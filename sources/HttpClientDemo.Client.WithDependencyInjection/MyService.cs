namespace DustInTheWind.HttpClientDemo.Client.WithDependencyInjection;

internal sealed class MyService : IDisposable
{
    private readonly HttpClient httpClient;

    public MyService(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task Execute(CancellationToken cancellationToken)
    {
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("Dummy", cancellationToken);

        Console.WriteLine("StatusCode: " + httpResponseMessage.StatusCode);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}
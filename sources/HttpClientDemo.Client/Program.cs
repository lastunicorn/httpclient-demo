using DustInTheWind.HttpClientDemo.WebApiAccess;
using HttpClientDemo.Infrastructure;

namespace DustInTheWind.HttpClientDemo.Client.Simple;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using HttpClient httpClient = new(new AuthenticationHandler(new DummyHandler(new HttpClientHandler())))
        {
            BaseAddress = new Uri("https://localhost:7033")
        };

        using WebApiClient webApiClient = new(httpClient);

        await webApiClient.Execute(CancellationToken.None);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }
}
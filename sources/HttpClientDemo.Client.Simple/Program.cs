using DustInTheWind.HttpClientDemo.WebApiAccess;
using DustInTheWind.HttpClientDemo.Handlers;

namespace DustInTheWind.HttpClientDemo.Client.Simple;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        HttpClientHandler httpMessageHandler = new();
        Dummy2Handler dummy2Handler = new(httpMessageHandler);
        Dummy1Handler dummy1Handler = new(dummy2Handler);
        AuthenticationHandler authenticationHandler = new(dummy1Handler);

        using HttpClient httpClient = new(authenticationHandler)
        {
            BaseAddress = new Uri("https://localhost:7033")
        };

        using WebApiClient webApiClient = new(httpClient);

        await webApiClient.GetDemo(CancellationToken.None);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }
}
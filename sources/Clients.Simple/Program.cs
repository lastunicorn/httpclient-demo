using DustInTheWind.HttpClientWithMessageHandlersDemo.Common.MessageHandlers;
using DustInTheWind.HttpClientWithMessageHandlersDemo.Common;

namespace DustInTheWind.HttpClientWithMessageHandlersDemo.Clients.Simple;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        HttpClientHandler httpMessageHandler = new();
        Dummy2Handler dummy2Handler = new(httpMessageHandler);
        Dummy1Handler dummy1Handler = new(dummy2Handler);

        using HttpClient httpClient = new(dummy1Handler)
        {
            BaseAddress = new Uri("https://localhost:7033")
        };

        using WebApiClient webApiClient = new(httpClient);

        await webApiClient.GetDemo(CancellationToken.None);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }
}
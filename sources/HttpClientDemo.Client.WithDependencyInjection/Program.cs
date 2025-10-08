using DustInTheWind.HttpClientDemo.WebApiAccess;
using HttpClientDemo.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DustInTheWind.HttpClientDemo.Client.WithDependencyInjection;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using ServiceProvider serviceProvider = ConfigureServices();
        await Execute(serviceProvider);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }

    private static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new();

        services
            .AddHttpClient<WebApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7033");
            })
            .AddHttpMessageHandler<AuthenticationHandler>()
            .AddHttpMessageHandler<DummyHandler>();

        services.AddTransient<AuthenticationHandler>();
        services.AddTransient<DummyHandler>();

        return services.BuildServiceProvider();
    }

    private static async Task Execute(ServiceProvider serviceProvider)
    {
        WebApiClient webApiClient = serviceProvider.GetService<WebApiClient>();
        await webApiClient.Execute(CancellationToken.None);
    }
}

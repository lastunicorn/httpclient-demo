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
        ServiceCollection services = new ServiceCollection();

        services.AddHttpClient<MyService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7033");
        });

        return services.BuildServiceProvider();
    }

    private static async Task Execute(ServiceProvider serviceProvider)
    {
        MyService myService = serviceProvider.GetService<MyService>();
        await myService.Execute(CancellationToken.None);
    }
}

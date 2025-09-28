using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace DustInTheWind.HttpClientDemo.Client.WithAutofac;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        IContainer container = ConfigureServices();
        await Execute(container);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }

    private static IContainer ConfigureServices()
    {
        // --- Microsoft.Extensions.DependencyInjection code ---

        ServiceCollection services = new();

        services.AddHttpClient<MyService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7033");
        });

        // --- Autofac specific code ---

        ContainerBuilder containerBuilder = new();

        containerBuilder.Populate(services);

        return containerBuilder.Build();
    }

    private static async Task Execute(IContainer container)
    {
        MyService myService = container.Resolve<MyService>();
        await myService.Execute(CancellationToken.None);
    }
}

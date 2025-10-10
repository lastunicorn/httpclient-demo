using Autofac;
using Autofac.Extensions.DependencyInjection;
using DustInTheWind.HttpClientDemo.Infrastructure;
using DustInTheWind.HttpClientDemo.WebApiAccess;
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

        services
            .AddHttpClient<WebApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7033");
            })
            .AddHttpMessageHandler<AuthenticationHandler>()
            .AddHttpMessageHandler<Dummy1Handler>()
            .AddHttpMessageHandler<Dummy2Handler>();

        // --- Autofac specific code ---

        ContainerBuilder containerBuilder = new();

        containerBuilder.Populate(services);

        containerBuilder.RegisterType<AuthenticationHandler>().AsSelf();
        containerBuilder.RegisterType<Dummy1Handler>().AsSelf();
        containerBuilder.RegisterType<Dummy2Handler>().AsSelf();

        return containerBuilder.Build();
    }

    private static async Task Execute(IContainer container)
    {
        WebApiClient webApiClient = container.Resolve<WebApiClient>();
        await webApiClient.GetDummy(CancellationToken.None);
    }
}

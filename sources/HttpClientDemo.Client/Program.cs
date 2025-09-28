namespace DustInTheWind.HttpClientDemo.Client.Simple;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using MyService myService = new(new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7033")
        });

        await myService.Execute(CancellationToken.None);

        Console.Write("Press any key to exit...");
        Console.ReadKey(false);
    }
}
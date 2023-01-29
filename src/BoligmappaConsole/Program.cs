namespace BoligmappaConsole;

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BoligmappaConsole.Interfaces.IConsoleOrchestrator;
using BoligmappaConsole.Classes.ConsoleOrchestrator;

public static class Program
{
    private const string CONF_DIRECTORY = "/conf";

    private static void Main(string[] args)
    {
        var host = CreateHost(args);
        host.Services.GetRequiredService<IConsoleOrchestrator>().Run();
    }

    private static IHost CreateHost(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(configuration =>
            {
                configuration
                    .SetBasePath(Directory.GetCurrentDirectory() + CONF_DIRECTORY)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices(services =>
            {
                services.AddTransient<IConsoleOrchestrator, ConsoleOrchestrator>();
            })
            .Build();
    }
}


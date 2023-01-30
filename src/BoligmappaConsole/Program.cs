namespace BoligmappaConsole;

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BoligmappaConsole.Interfaces.IConsoleOrchestrator;
using BoligmappaConsole.Interfaces.IDummyJsonService;
using BoligmappaConsole.Classes.ConsoleOrchestrator;
using BoligmappaConsole.Classes;
using BoligmappaConsole.Data;

public static class Program
{
    private const string CONF_DIRECTORY = "/conf";

    private static async Task Main(string[] args)
    {
        var host = CreateHost(args);
        await host.Services.GetRequiredService<IConsoleOrchestrator>().RunAsync();
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
                services.AddDbContext<BoligmappaContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("BoligmappaConnection")));
                
                services.AddTransient<IConsoleOrchestrator, ConsoleOrchestrator>();
                services.AddTransient<IDummyJsonService, DummyJsonService>();
                services.AddHttpClient();
            })
            .Build();
    }
}


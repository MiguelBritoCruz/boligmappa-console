namespace BoligmappaConsole.Classes.ConsoleOrchestrator;

using BoligmappaConsole.Interfaces.IConsoleOrchestrator;
using BoligmappaConsole.Interfaces.IDummyJsonService;
using BoligmappaConsole.Data;
using System.Threading.Tasks;

public class ConsoleOrchestrator : IConsoleOrchestrator
{
    private readonly IDummyJsonService dummyJsonService;
    private readonly BoligmappaContext boligmappaContext;
    public ConsoleOrchestrator(IDummyJsonService dummyJsonService, BoligmappaContext boligmappaContext)
    {
        this.dummyJsonService = dummyJsonService;
        this.boligmappaContext = boligmappaContext;
    }
    public async Task RunAsync()
    {
        
        // Unfortunately Json Deserialization is not working so I am not getting content
        // from API. In further commits, I will just specify how I would proceed.
        var users = this.dummyJsonService.GetUsersAsync();
        var posts = this.dummyJsonService.GetPostsAsync();
        var todos = this.dummyJsonService.GetTodosAsync();

        await Task.WhenAll(users, posts, todos);
    }
}
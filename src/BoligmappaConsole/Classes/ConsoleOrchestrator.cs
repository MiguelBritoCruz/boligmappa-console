namespace BoligmappaConsole.Classes.ConsoleOrchestrator;

using BoligmappaConsole.Interfaces.IConsoleOrchestrator;
using BoligmappaConsole.Interfaces.IDummyJsonService;
using System.Threading.Tasks;

public class ConsoleOrchestrator : IConsoleOrchestrator
{
    private readonly IDummyJsonService dummyJsonService;
    public ConsoleOrchestrator(IDummyJsonService dummyJsonService)
    {
        this.dummyJsonService = dummyJsonService;
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
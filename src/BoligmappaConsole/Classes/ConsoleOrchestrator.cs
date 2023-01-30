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

          //Group posts by userId | posts.GroupBy(x => x.UserId) -> IEnumerable<int, Post> -> ?? convert them to IEnumerable<Posts>
          //Group todos by userId | todos.GroupBy(x => x.UserId) -> IEnumerable<int, UserTodo> -> ?? convert them to IEnumerable<UserTodos>

          //Join posts and todos to create IEnumerable<UserDetail>
          // details = posts.Join(todos
          //      p => p.UserId,
          //      t => t.UserId,
          //      (p, t) => new UserDetail{UserId=p.UserId}      
          //)

          //----------------------------------------------------------------------------------
          //Adding the entities to the table 
          //(Could maybe add intermediate repo class that would encapsulate this logic and the query logic)
          //
          //foreach (var user in users) -> Users
          //{
          //    context.Users.Add(user);
          //}
          //
          //foreach (var post in Posts) -> Posts
          //{
          //    context.Posts.Add(post);
          //}
          //
          //foreach (var todo in Todos) -> UserTodos
          //{
          //    context.UserTodos.Add(todo);
          //}
          //
          //foreach (var detail in details) -> UserDetails
          //{
          //    context.UserDetails.Add(detail);
          //}
          //
          //boligmappaContex..SaveChanges();

        await Task.WhenAll(users, posts, todos);
    }
}
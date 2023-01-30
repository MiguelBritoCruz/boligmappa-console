namespace BoligmappaConsole.Interfaces.IDummyJsonService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligmappaConsole.Models;

public interface IDummyJsonService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<IEnumerable<Post>> GetPostsAsync();
    Task<IEnumerable<UserTodo>> GetTodosAsync();
}
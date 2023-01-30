using System;
using System.Net.Http.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BoligmappaConsole.Interfaces.IDummyJsonService;
using BoligmappaConsole.Models;

namespace BoligmappaConsole.Classes;

public class DummyJsonService : IDummyJsonService
{
    private const string ENDPOINT = "DummyAPI:endpoint";
    private const string USERS_URI = "users?select=firstName,lastName,age,email";
    private const string POSTS_URI = "posts?select=userId,reactions,tags";
    private const string TODOS_URI = "todos?select=userId,todo";
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;

    public DummyJsonService(HttpClient httpClient, IConfiguration configuration)
    {
        this.configuration = configuration;

        this.httpClient = httpClient;
        httpClient.BaseAddress = new Uri(this.configuration.GetSection(ENDPOINT).Value);

    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var result = new List<User>();

         try
        {

            var response = await this.httpClient.GetAsync(USERS_URI);

            Console.WriteLine(response);

            if (response?.IsSuccessStatusCode == true)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<User>>() ?? result;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Error fetching users from API");
        }
            
        return result;
    }
    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        var result = new List<Post>();

         try
        {

            var response = await this.httpClient.GetAsync(POSTS_URI);

            Console.WriteLine(response);

            if (response?.IsSuccessStatusCode == true)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Post>>() ?? result;
            }

        }
        catch (Exception)
        {
            Console.WriteLine("Error fetching posts from API");
        }
            
        return result;
    }
    public async Task<IEnumerable<UserTodo>> GetTodosAsync()
    {
        var result = new List<UserTodo>();

         try
        {

            var response = await this.httpClient.GetAsync(TODOS_URI);

            Console.WriteLine(response);

            if (response?.IsSuccessStatusCode == true)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<UserTodo>>() ?? result;
            }

        }
        catch (Exception)
        {
            Console.WriteLine("Error fetching todos from API");
        }
            
        return result;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligmappaConsole.Models
{
    public class UserTodo
    {
        public int UserTodoId {get; set;}
        public int UserId {get; set;}
        public string? Todo {get; set;}
        public bool Completed {get; set;}   
    }
}
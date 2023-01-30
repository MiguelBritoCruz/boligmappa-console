using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligmappaConsole.Models;

namespace BoligmappaConsole.Models
{
    public class UserDetail
    {
        public int UserId {get; set;}
        public int PostCount {get; set;}
        public IEnumerable<UserTodo> Todos {get; set;}
    }
}
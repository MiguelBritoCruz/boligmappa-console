using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligmappaConsole.Models
{
    public class Post
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public int Reactions {get; set;}
        public IEnumerable<string> Tags {get; set;}   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoligmappaConsole.Models
{
    public class Post
    {
        public int PostId {get; set;}
        public int UserId {get; set;}
        public int Reactions {get; set;}
        public string[] Tags {get; set;}   
    }
}
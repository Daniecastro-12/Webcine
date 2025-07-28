using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class TMDBGenre
    {
        public int id { get; set; }
        public string name { get; set; }



        public TMDBGenre(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public TMDBGenre()
        {
        }
    }
}
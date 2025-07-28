using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class TMDBProductionCountry
    {
        public TMDBProductionCountry()
        {
        }

        public string iso_3166_1 { get; set; }
        public string name { get; set; }

        public TMDBProductionCountry(string iso_3166_1, string name)
        {
            this.iso_3166_1 = iso_3166_1;
            this.name = name;
        }
    }
}
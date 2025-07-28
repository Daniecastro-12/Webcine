using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class TMDBSpokenLanguage
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }

        public TMDBSpokenLanguage(string iso_639_1, string name)
        {
            this.iso_639_1 = iso_639_1;
            this.name = name;
        }

        public TMDBSpokenLanguage()
        {
        }
    }
}
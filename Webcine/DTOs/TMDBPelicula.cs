using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class TMDBPelicula
    {
        public int id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int runtime { get; set; }
        public string original_language { get; set; }
        public string poster_path { get; set; }
        public string tagline { get; set; }
        public string status { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public double vote_average { get; set; }
        public string backdrop_path { get; set; }
        public string original_title { get; set; }
        public bool adult { get; set; }

        //public string adult { get; set; }
       // public List<TMDBGenre> genres { get; set; }
        //public string[] genres { get; set; } // Puedes mapear esto a string si lo necesitas simple
        public string genre_ids { get; set; }
       //public string spoken_languages { get; set; }
        //public string production_countries { get; set; }
        public string popularity { get; set; }

        public List<TMDBGenre> genres { get; set; }
        public List<TMDBProductionCountry> production_countries { get; set; }
        public List<TMDBSpokenLanguage> spoken_languages { get; set; }

        public TMDBPelicula(int id, string title, string overview, string release_date, int runtime, string original_language, string poster_path, string tagline, string status, string homepage, string imdb_id, double vote_average, string backdrop_path, string original_title, bool adult, string genre_ids, string popularity, List<TMDBGenre> genres, List<TMDBProductionCountry> production_countries, List<TMDBSpokenLanguage> spoken_languages)
        {
            this.id = id;
            this.title = title;
            this.overview = overview;
            this.release_date = release_date;
            this.runtime = runtime;
            this.original_language = original_language;
            this.poster_path = poster_path;
            this.tagline = tagline;
            this.status = status;
            this.homepage = homepage;
            this.imdb_id = imdb_id;
            this.vote_average = vote_average;
            this.backdrop_path = backdrop_path;
            this.original_title = original_title;
            this.adult = adult;
            this.genre_ids = genre_ids;
            this.popularity = popularity;
            this.genres = genres;
            this.production_countries = production_countries;
            this.spoken_languages = spoken_languages;
        }

        public TMDBPelicula()
        {
        }
    }
}
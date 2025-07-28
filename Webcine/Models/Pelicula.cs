using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Pelicula
    {
        public int _id;
        public string _titulo;
        public string _genero;
        public int _duracion;
        public string _clasificacion;
        public string _sinopsis;
        public string _idioma;
        public DateTime _fechaEstreno;
        public int IdExterna { get; set; } // ID de la película en TMDB

        [JsonIgnore]
        public List<Funcion> Funciones { get; set; }

        public Pelicula()
        {
        }
        public Pelicula(int id, string titulo, string genero, int duracion, string clasificacion, string sinopsis, string idioma, DateTime fechaEstreno)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Duracion = duracion;
            Clasificacion = clasificacion;
            Sinopsis = sinopsis;
            Idioma = idioma;
            FechaEstreno = fechaEstreno;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        public int Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }
        public string Clasificacion
        {
            get { return _clasificacion; }
            set { _clasificacion = value; }
        }
        public string Sinopsis
        {
            get { return _sinopsis; }
            set { _sinopsis = value; }
        }
        public string Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }
        public DateTime FechaEstreno
        {
            get { return _fechaEstreno; }
            set { _fechaEstreno = value; }
        }

        public override string ToString()
        {
            return $"Película ID: {Id}, Título: {Titulo}, Duración: {Duracion} min";
        }
    }

}

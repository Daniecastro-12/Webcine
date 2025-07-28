using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Funcion
    {
        public int _id;
        public int _peliculaId { get; set; }
        [JsonIgnore]
        public Pelicula _pelicula;

        public int _salaId { get; set; }
        [JsonIgnore]
        public Sala _sala;

        [JsonIgnore]
        public List<Boleto> Boletos { get; set; }

        public DateTime _fechaHora;
        public decimal _precioEntrada;
        public int _asientosDisponibles;
        [JsonIgnore]
        public virtual ICollection<Asiento> Asientos { get; set; }

        

        public Funcion()
        {
        }
        public Funcion(int id, Pelicula pelicula, Sala sala, DateTime fechaHora, decimal precioEntrada, int asientosDisponibles)
        {
            Id = id;
            Pelicula = pelicula;
            Sala = sala;
            FechaHora = fechaHora;
            PrecioEntrada = precioEntrada;
            AsientosDisponibles = asientosDisponibles;
            Boletos = new List<Boleto>();
            Asientos = new List<Asiento>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Pelicula Pelicula
        {
            get { return _pelicula; }
            set { _pelicula = value; }
        }
        public Sala Sala
        {
            get { return _sala; }
            set { _sala = value; }
        }
        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; }
        }
        public decimal PrecioEntrada
        {
            get { return _precioEntrada; }
            set { _precioEntrada = value; }
        }
        public int AsientosDisponibles
        {
            get { return _asientosDisponibles; }
            set { _asientosDisponibles = value; }
        }

        public override string ToString()
        {
            return $"Función ID: {Id}, Película: {_pelicula.Titulo}, Sala: {_sala.Nombre}";
        }
    }
}

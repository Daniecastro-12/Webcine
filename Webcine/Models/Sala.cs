using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models    
{
    
    public class Sala
    {
        public int _id;
        public string _nombre;
        public int _capacidad;
        public string _tipo;
        public string _ubicacion;

        public List<Funcion> Funciones { get; set; }
        public virtual ICollection<Asiento> Asientos { get; set; }

        public Sala()
        {
        }
        public Sala(int id, string nombre, int capacidad, string tipo, string ubicacion)
        {
            Id = id;
            Nombre = nombre;
            Capacidad = capacidad;
            Tipo = tipo;
            Ubicacion = ubicacion;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
            {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        public override string ToString()
        {
            return $"Sala ID: {Id}, Nombre: {_nombre}, Capacidad: {_capacidad}";
        }
    }
}

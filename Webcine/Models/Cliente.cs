using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Cliente : Persona
    {
        public int _id;
        public string _correo;
        public string _telefono;
        public List<Factura> _historialCompras = new List<Factura>();

        public List<Reserva> _reservas { get; set; }
        

        public Cliente()
        {
        }

        public Cliente(int id, string nombre, string apellido, DateTime fechaNacimiento, string domicilio, string genero, string nacionalidad, string correo, string telefono)
            : base(id, nombre, apellido, fechaNacimiento, domicilio, genero, nacionalidad)
        {
            Id = id;
            Correo = correo;
            Telefono = telefono;
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public List<Factura> HistorialCompras
        {
            get { return _historialCompras; }
            set { _historialCompras = value; }
        }

        public override string ToString()
        {
            return $"Cliente ID: {Id}, {base.ToString()}, Contacto: {Correo} | {Telefono}";
        }
    }

}

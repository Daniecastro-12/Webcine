using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _email;
        private DateTime _fechaNacimiento;
        private string _domicilio;
        private string _genero;
        private string _nacionalidad;


        public Persona()
        {
        }

        public Persona(int id, string nombre, string apellido, DateTime fechaNacimiento, string domicilio, string genero, string nacionalidad)
        {

            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Domicilio = domicilio;
            Genero = genero;
            Nacionalidad = nacionalidad;
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

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellido}, Nacionalidad: {Nacionalidad}, Fecha Nacimiento: {FechaNacimiento.ToShortDateString()}";
        }
    }
}

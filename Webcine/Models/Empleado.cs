using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Empleado : Persona
    {
        private int _id;
        private string _puesto;
        private decimal _sueldo;
        private DateTime _fechaContratacion;
        private Departamento _departamento;

        public Empleado()
        {
        }

        public Empleado(int id, string nombre, string apellido, DateTime fechaNacimiento, string domicilio, string genero, string nacionalidad, string puesto, decimal sueldo, DateTime fechaContratacion, Departamento departamento)
            : base(id, nombre, apellido, fechaNacimiento, domicilio, genero, nacionalidad)
        {
            Id = id;
            Puesto = puesto;
            Sueldo = sueldo;
            FlechaContratacion = fechaContratacion;
            _departamento = departamento;
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; }
        }

        public decimal Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }
        public DateTime FlechaContratacion
        {
            get { return _fechaContratacion; }
            set { _fechaContratacion = value; }
        }
        public Departamento departamento
        {
            get { return _departamento; }
            set { _ = value; }
        }




        public override string ToString()
        {
            return $"Empleado ID: {Id}, {base.ToString()}, Puesto: {Puesto}";
        }
    }
}

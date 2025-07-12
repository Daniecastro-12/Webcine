using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Departamento
    {
        public int _id;
        public string _nombre;
        public string _descripcion;
        public List<Empleado> _listaEmpleados = new List<Empleado>();

        public Departamento()
        {
        }
        public Departamento(int id, string nombre, string descripcion, List<Empleado> listaEmpleados)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            ListaEmpleados = listaEmpleados;
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
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public List<Empleado> ListaEmpleados
        {
            get { return _listaEmpleados; }
            set { _listaEmpleados = value; }
        }

        public override string ToString()
        {
            return $"Departamento: {Nombre}, ID: {Id}, Empleados: {_listaEmpleados.Count}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class MetodoPago
    {
        public int _id;
        public string _nombre;
        public string _descripcion;

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

        public override string ToString()
        {
            return $"Id Método de pago: {Id},Método de pago: {Nombre}";
        }
    }
}

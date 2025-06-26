using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models    
{
   public class Cartelera
    {
        private int _id;
        private DateTime _fecha;
        private List<Funcion> _listaFunciones = new List<Funcion>();

        public Cartelera()
        {
        }
        public Cartelera(int id, DateTime fecha, List<Funcion> listaFunciones)
        {
            Id = id;
            Fecha = fecha;
            ListaFunciones = listaFunciones;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public List<Funcion> ListaFunciones
        {
            get { return _listaFunciones; }
            set { _listaFunciones = value; }
        }

        public override string ToString()
        {
            return $"Cartelera del {_fecha.ToShortDateString()}, Funciones: {_listaFunciones.Count}";
        }
    }
}

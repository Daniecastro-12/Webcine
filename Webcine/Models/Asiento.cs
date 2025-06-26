using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Asiento
    {
        private int _id;
        private string _fila;
        private int _columna;
        private bool _disponible;

        public Asiento()
        {
        }

        public Asiento(int id, string fila, int columna, bool disponible)
        {
            Id = id;
            Fila = fila;
            Columna = columna;
            Disponible = disponible;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }
        public int Columna
        {
            get { return _columna; }
            set { _columna = value; }
        }
        public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        public override string ToString()
        {
            return $"Asiento: {_fila}{_columna}, Disponible: {_disponible}";
        }
    }
}

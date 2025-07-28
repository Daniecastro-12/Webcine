using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Asiento
    {
        //dfff
        public int _id;
        public string _fila;
        public int _columna;
        public bool _disponible;

        public int FuncionId { get; set; }
        [ForeignKey("FuncionId")]
        public virtual Funcion Funcion { get; set; }

        public int SalaId { get; set; }     
        public virtual Sala Sala { get; set; }

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

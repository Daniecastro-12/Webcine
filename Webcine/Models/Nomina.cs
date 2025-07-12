using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Nomina
    {
        private int _id;


        public int _empleadoId { get; set; }
        public Empleado _empleado;


        public DateTime _fechaPago;
        public decimal _monto;
        public int _horasTrabajadas;
        public string _periodo;

        public Nomina()
        {
        }
        public Nomina(int id, Empleado empleado, DateTime fechaPago, decimal monto, int horasTrabajadas, string periodo)
        {
            Id = id;
            Empleado = empleado;
            FechaPago = fechaPago;
            Monto = monto;
            HorasTrabajadas = horasTrabajadas;
            Periodo = periodo;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public Empleado Empleado
        {
            get { return _empleado; }
            set { _empleado = value; }
        }
        public DateTime FechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }
        public int HorasTrabajadas
        {
            get { return _horasTrabajadas; }
            set { _horasTrabajadas = value; }
        }
        public string Periodo
        {
            get { return _periodo; }
            set { _periodo = value; }
        }


        public override string ToString()
        {
            return $"Nómina ID: {Id}, Empleado: {_empleado.Nombre}, Monto: {Monto:C}";
        }
    }
}

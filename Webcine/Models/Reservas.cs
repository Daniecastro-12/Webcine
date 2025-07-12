using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models    
{
    public class Reserva
    {
        private int _id;

        public int _clienteId { get; set; }
        public Cliente _cliente;

        public int _funcionId { get; set; }
        public Funcion _funcion;




        public int _cantidadBoletos;
        public List<Asiento> _listaAsientos = new List<Asiento>();
        public bool _estadoPago;


        public Reserva()
        {
        }
        public Reserva(int id, Cliente cliente, Funcion funcion, int cantidadBoletos, List<Asiento> listaAsientos, bool estadoPago)
        {
            Id = id;
            Cliente = cliente;
            Funcion = funcion;
            CantidadBoletos = cantidadBoletos;
            ListaAsientos = listaAsientos;
            EstadoPago = estadoPago;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public Funcion Funcion
        {
            get { return _funcion; }
            set { _funcion = value; }
        }
        public int CantidadBoletos
        {
            get { return _cantidadBoletos; }
            set { _cantidadBoletos = value; }
        }
        public List<Asiento> ListaAsientos
        {
            get { return _listaAsientos; }
            set { _listaAsientos = value; }
        }
        public bool EstadoPago
        {
            get { return _estadoPago; }
            set { _estadoPago = value; }
        }

        public override string ToString()
        {
            return $"Reserva ID: {Id}, Cliente: {_cliente.Nombre}, Boletos: {_cantidadBoletos}";
        }
    }
}

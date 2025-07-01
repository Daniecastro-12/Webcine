using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Boleto
    {
        private int _id;
        private Reserva _reserva;
        private Funcion _funcion;
        private Asiento _asiento;
        private decimal _precio;
        private string _codigoQR;

        public Boleto()
        {
        }
        public Boleto(int id, Reserva reserva, Funcion funcion, Asiento asiento, decimal precio, string codigoQR)
        {
            Id = id;
            Reserva = reserva;
            Funcion = funcion;
            Asiento = asiento;
            Precio = precio;
            CodigoQR = codigoQR;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Reserva Reserva
        {
            get { return _reserva; }
            set { _reserva = value; }
        }
        public Funcion Funcion
        {
            get { return _funcion; }
            set { _funcion = value; }
        }
        public Asiento Asiento
        {
            get { return _asiento; }
            set { _asiento = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string CodigoQR
        {
            get { return _codigoQR; }
            set { _codigoQR = value; }
        }
        public override string ToString()
        {
            return $"Boleto ID: {Id}, Asiento: {_asiento}, Precio: {_precio:C}";
        }
    }
}

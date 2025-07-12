using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Boleto
    {
        public int _id;

        public int _reservaId { get; set; } 
        public Reserva _reserva;

        public int _funcionId { get; set; }
        public Funcion _funcion;

        public int _asientoId { get; set; }
        public Asiento _asiento;


        public decimal _precio;
        public string _codigoQR;



        public Boleto()
        {
        }

        public Boleto(int reservaId, int funcionId, int asientoId, int id, Reserva reserva, Funcion funcion, Asiento asiento, decimal precio, string codigoQR)
        {
            _reservaId = reservaId;
            _funcionId = funcionId;
            _asientoId = asientoId;
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

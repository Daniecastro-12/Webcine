using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCine.Models;

namespace Webcine.Models
{
    public class ReservaDetalle
    {
        public ReservaDetalle()
        {
        }

        public int Id { get; set; }

        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }

        public int TipoEntradaId { get; set; }
        public TipoEntrada TipoEntrada { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
        public decimal Servicio { get; set; }

        public ReservaDetalle(int id, int reservaId, Reserva reserva, int tipoEntradaId, TipoEntrada tipoEntrada, int cantidad, decimal precio, decimal servicio)
        {
            Id = id;
            ReservaId = reservaId;
            Reserva = reserva;
            TipoEntradaId = tipoEntradaId;
            TipoEntrada = tipoEntrada;
            Cantidad = cantidad;
            Precio = precio;
            Servicio = servicio;
        }
    }
}
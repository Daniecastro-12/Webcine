using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class DetalleReservaDTO
    {
        public DetalleReservaDTO()
        {
        }

        public int TipoEntradaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Servicio { get; set; }

        public DetalleReservaDTO(int tipoEntradaId, int cantidad, decimal precio, decimal servicio)
        {
            TipoEntradaId = tipoEntradaId;
            Cantidad = cantidad;
            Precio = precio;
            Servicio = servicio;
        }
    }
}
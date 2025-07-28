using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class DetalleFacturaDTO
    {
        public string Tipo { get; set; }           // "Asiento", "Snack"
        public string Descripcion { get; set; }    // "Fila J, Asiento 11"
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public DetalleFacturaDTO(string tipo, string descripcion, int cantidad, decimal precioUnitario, decimal subtotal)
        {
            Tipo = tipo;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
        }

        public DetalleFacturaDTO()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }                  // Relación con Factura
        public string Tipo { get; set; }                    // Ejemplo: "Asiento", "Snack"
        public string Descripcion { get; set; }             // Ejemplo: "Fila J, Asiento 11"
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public virtual Factura Factura { get; set; }

        public DetalleFactura()
        {
        }

        public DetalleFactura(int id, int facturaId, string tipo, string descripcion, int cantidad, decimal precioUnitario, decimal subtotal, Factura factura)
        {
            Id = id;
            FacturaId = facturaId;
            Tipo = tipo;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
            Factura = factura;
        }
    }
}

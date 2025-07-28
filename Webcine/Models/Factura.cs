using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        
        public virtual ICollection<DetalleFactura > Detalles { get; set; }


        public Factura()
        {
        }

        public Factura(int id, string nombreCliente, string apellidoCliente, string emailCliente, DateTime fecha, decimal total, ICollection<DetalleFactura> detalles)
        {
            Id = id;
            NombreCliente = nombreCliente;
            ApellidoCliente = apellidoCliente;
            EmailCliente = emailCliente;
            Fecha = fecha;
            Total = total;
            Detalles = detalles;
        }
    }
}

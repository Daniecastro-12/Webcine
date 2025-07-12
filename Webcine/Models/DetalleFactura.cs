using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class DetalleFactura
    {
        public int _id;
        public int _cantidad;
        public string _descripcion;
        public decimal _precioUnitario;
        public decimal _subtotal;

        public int _facturaId { get; set; }
        public Factura _factura { get; set; }

        public DetalleFactura()
        {
        }

        public DetalleFactura(int id, int cantidad, decimal subtotal, string descripcion, decimal precioUnitario)
        {
            Id = id;
            Cantidad = cantidad;
            Subtotal = subtotal;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal PrecioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        public override string ToString()
        {
            return $"IdDetalle: {Id}, Detalle: {_descripcion}, Cantidad: {Cantidad}, Subtotal: {Subtotal:C}";
        }
    }
}

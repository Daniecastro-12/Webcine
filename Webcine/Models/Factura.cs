using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCine.Models
{
    public class Factura
    {
        public int _id;

        public int _clienteId { get; set; }
        public Cliente _cliente;


        public DateTime _fecha;



        public List<DetalleFactura> _listaDetalles = new List<DetalleFactura>();


        public decimal _total;

        public int _metodoPagoId { get; set; }
        public MetodoPago _metodoPago;


        public Factura()
        {
        }
        public Factura(int id, Cliente cliente, DateTime fecha, List<DetalleFactura> listaDetalles, decimal total, MetodoPago metodoPago)
        {
            Id = id;
            Cliente = cliente;
            Fecha = fecha;
            ListaDetalles = listaDetalles;
            Total = total;
            MetodoPago = metodoPago;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public List<DetalleFactura> ListaDetalles
        {
            get { return _listaDetalles; }
            set { _listaDetalles = value; }
        }
        public MetodoPago MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }

        public override string ToString()
        {
            return $"Factura ID: {Id}, Cliente: {_cliente.Nombre}, Total: {Total:C}";
        }
    }
}

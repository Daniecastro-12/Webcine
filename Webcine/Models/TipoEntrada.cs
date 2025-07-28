using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.Models
{
    public class TipoEntrada
    {
        public TipoEntrada()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; } // Adulto, Niño, etc.
        public decimal PrecioBase { get; set; }
        public decimal CostoServicio { get; set; }

        public TipoEntrada(int id, string nombre, decimal precioBase, decimal costoServicio)
        {
            Id = id;
            Nombre = nombre;
            PrecioBase = precioBase;
            CostoServicio = costoServicio;
        }
    }
}
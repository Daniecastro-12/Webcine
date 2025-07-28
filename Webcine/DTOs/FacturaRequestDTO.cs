using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class FacturaRequestDTO
    {
        public ClienteDTO Cliente { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }
        public decimal Total { get; set; }

        public FacturaRequestDTO(ClienteDTO cliente, List<DetalleFacturaDTO> detalles, decimal total)
        {
            Cliente = cliente;
            Detalles = detalles;
            Total = total;
        }

        public FacturaRequestDTO()
        {
        }
    }
}
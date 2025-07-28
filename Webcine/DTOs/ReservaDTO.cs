using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class ReservaDTO
    {
        public ReservaDTO()
        {
        }

        public int ClienteId { get; set; }
        public int FuncionId { get; set; }

        public List<DetalleReservaDTO> Detalles { get; set; }

        public ReservaDTO(int clienteId, int funcionId, List<DetalleReservaDTO> detalles)
        {
            ClienteId = clienteId;
            FuncionId = funcionId;
            Detalles = detalles;
        }
    }
}
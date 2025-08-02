using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class FuncionTipoEntradaDTO
    {
        public FuncionTipoEntradaDTO()
        {
        }

        public int Id { get; set; }
        public int FuncionId { get; set; }
        public int TipoEntradaId { get; set; }
        public int Disponibles { get; set; }

        public FuncionTipoEntradaDTO(int id, int funcionId, int tipoEntradaId, int disponibles)
        {
            Id = id;
            FuncionId = funcionId;
            TipoEntradaId = tipoEntradaId;
            Disponibles = disponibles;
        }
    }
}
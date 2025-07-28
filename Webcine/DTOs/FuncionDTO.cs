using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class FuncionDTO
    {
        public int _peliculaId { get; set; }
        public int _salaId { get; set; }
        public DateTime _fechaHora { get; set; }
        public decimal _precioEntrada { get; set; }
        public int _asientosDisponibles { get; set; }

        public FuncionDTO(int peliculaId, int salaId, DateTime fechaHora, decimal precioEntrada, int asientosDisponibles)
        {
            _peliculaId = peliculaId;
            _salaId = salaId;
            _fechaHora = fechaHora;
            _precioEntrada = precioEntrada;
            _asientosDisponibles = asientosDisponibles;
        }

        public FuncionDTO()
        {
        }
    }


}
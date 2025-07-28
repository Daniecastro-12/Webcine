using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class AsientoDTO
    {
        public AsientoDTO()
        {
        }

        public int Id { get; set; }
        public string Fila { get; set; }
        public int Columna { get; set; }
        public bool Disponible { get; set; }

        public AsientoDTO(int id, string fila, int columna, bool disponible)
        {
            Id = id;
            Fila = fila;
            Columna = columna;
            Disponible = disponible;
        }
    }
}
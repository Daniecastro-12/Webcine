using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class SalaDTO
    {
        
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Tipo {  get; set; }
        public string Ubicacion { get; set; }


        public SalaDTO(string nombre, int capacidad, string tipo, string ubicacion)
        {
            Nombre = nombre;
            Capacidad = capacidad;
            Tipo = tipo;
            Ubicacion = ubicacion;
        }

        public SalaDTO()
        {
        }
    }
}
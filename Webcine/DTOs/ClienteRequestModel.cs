using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class ClienteRequestModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public ClienteRequestModel(string nombre, string apellido, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
        }

        public ClienteRequestModel()
        {
        }
    }
}
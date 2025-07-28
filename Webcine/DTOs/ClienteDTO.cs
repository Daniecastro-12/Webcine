using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class ClienteDTO
    {
        public ClienteDTO()
        {
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public ClienteDTO(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }
    }
}
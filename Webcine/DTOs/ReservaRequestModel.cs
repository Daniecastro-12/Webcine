using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webcine.DTOs
{
    public class ReservaRequestModel
    {
        public ClienteRequestModel Cliente { get; set; }
        public int FuncionId { get; set; }
        public List<int> Asientos { get; set; }
        public Dictionary<string, int> Cantidades { get; set; }
        public decimal Total { get; set; }

        public ReservaRequestModel(ClienteRequestModel cliente, int funcionId, List<int> asientos, Dictionary<string, int> cantidades, decimal total)
        {
            Cliente = cliente;
            FuncionId = funcionId;
            Asientos = asientos;
            Cantidades = cantidades;
            Total = total;
        }

        public ReservaRequestModel()
        {
        }
    }
}
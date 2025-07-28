using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webcine.Models;

namespace WebCine.Models    
{
    public class Reserva
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;

        public bool EstadoPago { get; set; }

        public virtual ICollection<ReservaDetalle> Detalles { get; set; } // Detalle por tipo de entrada

        public virtual ICollection<Asiento> Asientos { get; set; } // Asientos reservados opcionalmente


        public Reserva()
        {
        }

        public Reserva(int id, int clienteId, Cliente cliente, int funcionId, Funcion funcion, DateTime fechaReserva, bool estadoPago, ICollection<ReservaDetalle> detalles, ICollection<Asiento> asientos)
        {
            Id = id;
            ClienteId = clienteId;
            Cliente = cliente;
            FuncionId = funcionId;
            Funcion = funcion;
            FechaReserva = fechaReserva;
            EstadoPago = estadoPago;
            Detalles = detalles;
            Asientos = asientos;
        }
    }
}

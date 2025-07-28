using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCine.Models;

namespace Webcine.Models
{
    public class FuncionTipoEntrada
    {
        public int Id { get; set; }

        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; }

        public int TipoEntradaId { get; set; }
        public TipoEntrada TipoEntrada { get; set; }

        public int Disponibles { get; set; } // para controlar cupo por tipo

        public FuncionTipoEntrada(int id, int funcionId, Funcion funcion, int tipoEntradaId, TipoEntrada tipoEntrada, int disponibles)
        {
            Id = id;
            FuncionId = funcionId;
            Funcion = funcion;
            TipoEntradaId = tipoEntradaId;
            TipoEntrada = tipoEntrada;
            Disponibles = disponibles;
        }

        public FuncionTipoEntrada()
        {
        }
    }
}
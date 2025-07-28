using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Webcine.DTOs;
using Webcine.Models;
using WebCine.Models;

namespace Webcine.Controllers
{
    public class ReservasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Reservas
        public IQueryable<Reserva> GetReservas()
        {
            return db.Reservas;
        }

        // GET: api/Reservas/5
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult GetReserva(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }



        [HttpPost]
        [Route("crear-reserva-con-detalles")]
        public IHttpActionResult CrearReserva(ReservaDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reserva = new Reserva
            {
                ClienteId = dto.ClienteId,
                FuncionId = dto.FuncionId,
                FechaReserva = DateTime.Now,
                EstadoPago = false,
                Detalles = new List<ReservaDetalle>()
            };

            foreach (var detalle in dto.Detalles)
            {
                reserva.Detalles.Add(new ReservaDetalle
                {
                    TipoEntradaId = detalle.TipoEntradaId,
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio,
                    Servicio = detalle.Servicio
                });
            }

            db.Reservas.Add(reserva);
            db.SaveChanges();

            return Ok("Reserva creada con éxito");
        }

        [HttpPost]
        [Route("api/reservas")]
        public IHttpActionResult CrearReserva(ReservaRequestModel model)
        {
            // Buscar o crear cliente
            var cliente = db.Clientes.FirstOrDefault(c => c.Correo == model.Cliente.Correo);
            if (cliente == null)
            {
                cliente = new Cliente
                {
                    Nombre = model.Cliente.Nombre,
                    Apellido = model.Cliente.Apellido,
                    Correo = model.Cliente.Correo
                };
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }

            // Crear la reserva
            var reserva = new Reserva
            {
                ClienteId = cliente.Id,
                FuncionId = model.FuncionId,
                FechaReserva = DateTime.Now,
                EstadoPago = true
            };
            db.Reservas.Add(reserva);
            db.SaveChanges();

            // Agregar asientos reservados
            foreach (var idAsiento in model.Asientos)
            {
                var asiento = db.Asientos.Find(idAsiento);
                if (asiento != null)
                {
                    reserva.Asientos.Add(asiento);
                }
            }

            // Agregar detalles por tipo de entrada (usando Nombre y campos correctos)
            foreach (var kvp in model.Cantidades)
            {
                // Busca el TipoEntrada por NOMBRE
                var tipoEntrada = db.TipoEntradas.FirstOrDefault(te => te.Nombre == kvp.Key);
                if (tipoEntrada != null)
                {
                    reserva.Detalles.Add(new ReservaDetalle
                    {
                        ReservaId = reserva.Id,
                        TipoEntradaId = tipoEntrada.Id,
                        Cantidad = kvp.Value,
                        Precio = tipoEntrada.PrecioBase,
                        Servicio = tipoEntrada.CostoServicio
                    });
                }
            }

            db.SaveChanges();

            return Ok(new { id = reserva.Id });
        }





        // PUT: api/Reservas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReserva(int id, Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserva.Id)
            {
                return BadRequest();
            }

            db.Entry(reserva).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reservas
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult PostReserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservas.Add(reserva);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reserva.Id }, reserva);
        }

        // DELETE: api/Reservas/5
        [ResponseType(typeof(Reserva))]
        public IHttpActionResult DeleteReserva(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }

            db.Reservas.Remove(reserva);
            db.SaveChanges();

            return Ok(reserva);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaExists(int id)
        {
            return db.Reservas.Count(e => e.Id == id) > 0;
        }
    }
}
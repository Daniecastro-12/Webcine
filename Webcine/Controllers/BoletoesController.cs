using Swashbuckle.Swagger.Annotations;
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
using WebCine.Models;

namespace Webcine.Controllers
{
    public class BoletoesController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // HAY QUE REVISARLO
        /*[HttpGet]
        [Route("api/boletos/cliente-pelicula")]
        [SwaggerOperation("GetBoletosClientePelicula")]
        public IHttpActionResult GetBoletosClientePelicula()
        {
            var result = from boleto in db.Boletos
                         join reserva in db.Reservas on boleto._reservaId equals reserva.Id
                         join cliente in db.Clientes on reserva._cliente.Id equals cliente.Id
                         join funcion in db.Funciones on boleto._funcionId equals funcion.Id
                         join pelicula in db.Peliculas on funcion._pelicula.Id equals pelicula.Id
                         select new
                         {
                             BoletoId = boleto.Id,
                             Precio = boleto.Precio,
                             CodigoQR = boleto.CodigoQR,

                             Cliente = new
                             {
                                 Id = cliente.Id,
                                 Nombre = cliente.Nombre,
                                 Apellido = cliente.Apellido,
                                 Email = cliente.Email
                             },

                             Pelicula = new
                             {
                                 Id = pelicula.Id,
                                 Titulo = pelicula.Titulo,
                                 Genero = pelicula.Genero,
                                 Clasificacion = pelicula.Clasificacion
                             }
                         };

            return Ok(result);
        }*/



        /*[HttpGet]
        [Route("api/boletos/reservas")]
        [SwaggerOperation("GetBoletosPorEstadoReserva")]
        public IHttpActionResult GetBoletosPorEstadoReserva(bool estadoPago = true)
        {
            
            var result = from boleto in db.Boletos
                         join reserva in db.Reservas on boleto._reservaId equals reserva.Id
                         where reserva.EstadoPago == estadoPago // Filtro por estado de pago
                         select new
                         {
                             // Información del Boleto
                             BoletoId = boleto.Id,
                             Precio = boleto.Precio,
                             CodigoQR = boleto.CodigoQR,
                             AsientoId = boleto._asientoId,

                             // Información de la Reserva
                             ReservaId = reserva.Id,
                             CantidadBoletos = reserva.CantidadBoletos,
                             EstadoPago = reserva.EstadoPago
                         };

            return Ok(result.ToList());
        }*/




        // GET: api/Boletoes
        public IQueryable<Boleto> GetBoletos()
        {
            return db.Boletos;
        }

        // GET: api/Boletoes/5
        [ResponseType(typeof(Boleto))]
        public IHttpActionResult GetBoleto(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            if (boleto == null)
            {
                return NotFound();
            }

            return Ok(boleto);
        }

        // PUT: api/Boletoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoleto(int id, Boleto boleto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boleto.Id)
            {
                return BadRequest();
            }

            db.Entry(boleto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletoExists(id))
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

        // POST: api/Boletoes
        [ResponseType(typeof(Boleto))]
        public IHttpActionResult PostBoleto(Boleto boleto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boletos.Add(boleto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boleto.Id }, boleto);
        }

        // DELETE: api/Boletoes/5
        [ResponseType(typeof(Boleto))]
        public IHttpActionResult DeleteBoleto(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            if (boleto == null)
            {
                return NotFound();
            }

            db.Boletos.Remove(boleto);
            db.SaveChanges();

            return Ok(boleto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoletoExists(int id)
        {
            return db.Boletos.Count(e => e.Id == id) > 0;
        }
    }
}
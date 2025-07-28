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
    public class AsientoesController : ApiController
    {
        private MiDbContext db = new MiDbContext();



        [HttpGet]
        [Route("api/asientos/disponibles")]
        [SwaggerOperation("GetAsientosPorDisponibilidad")]
        public IHttpActionResult GetAsientosPorDisponibilidad(bool disponible = true)
        {
            var asientos = db.Asientos
                             .Include("Sala")
                             .Where(a => a._disponible == disponible)
                             .Select(a => new
                             {
                                 // Asiento info
                                 AsientoId = a.Id,
                                 Fila = a.Fila,
                                 Columna = a.Columna,
                                 Disponible = a.Disponible,

                                 // Sala info
                                 Sala = new
                                 {
                                     SalaId = a.Sala.Id,
                                     Nombre = a.Sala.Nombre,
                                     Capacidad = a.Sala.Capacidad,
                                     Tipo = a.Sala.Tipo,
                                     Ubicacion = a.Sala.Ubicacion
                                 }
                             })
                             .ToList();

            return Ok(asientos);
        }





        /*[HttpGet]
        [Route("api/asientos/por-funcion")]
        [SwaggerOperation("GetAsientosPorFuncion")]
        public IHttpActionResult GetAsientosPorFuncion(int funcionId)
        {
            var asientos = db.Asientos
                             .Where(a => a.FuncionId == funcionId)
                             .Select(a => new
                             {
                                 AsientoId = a.Id,
                                 Fila = a.Fila,
                                 Columna = a.Columna,
                                 Disponible = a.Disponible
                             })
                             .ToList();

            return Ok(asientos);
        }*/


        //
        [HttpGet]
        [Route("api/asientos/por-funcion")]
        public IHttpActionResult GetAsientosPorFuncion(int funcionId)
        {
            // Busca la función con la sala
            var funcion = db.Funciones
                .Include(f => f.Sala)
                .FirstOrDefault(f => f.Id == funcionId);

            if (funcion == null)
                return NotFound();

            // 1. Traer IDs de asientos reservados para esa función
            var asientosReservados = db.Reservas
                .Where(r => r.FuncionId == funcionId)
                .SelectMany(r => r.Asientos.Select(a => a.Id))
                .ToList();

            // 2. Traer TODOS los asientos de la sala y marcar si están reservados
            var asientos = db.Asientos
                .Where(a => a.SalaId == funcion._salaId)
                .Select(a => new {
                    a.Id,
                    a.Fila,
                    a.Columna,
                    Disponible = !asientosReservados.Contains(a.Id)
                })
                .ToList();

            return Ok(asientos);
        }










        // GET: api/Asientoes
        public IQueryable<Asiento> GetAsientos()
        {
            return db.Asientos;
        }

        // GET: api/Asientoes/5
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult GetAsiento(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return NotFound();
            }

            return Ok(asiento);
        }

        // PUT: api/Asientoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsiento(int id, Asiento asiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asiento.Id)
            {
                return BadRequest();
            }

            db.Entry(asiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoExists(id))
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

        // POST: api/Asientoes
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult PostAsiento(Asiento asiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asientos.Add(asiento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asiento.Id }, asiento);
        }

        // DELETE: api/Asientoes/5
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult DeleteAsiento(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return NotFound();
            }

            db.Asientos.Remove(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsientoExists(int id)
        {
            return db.Asientos.Count(e => e.Id == id) > 0;
        }
    }
}
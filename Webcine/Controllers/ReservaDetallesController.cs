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
using Webcine.Models;

namespace Webcine.Controllers
{
    public class ReservaDetallesController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/ReservaDetalles
        public IQueryable<ReservaDetalle> GetReservaDetalles()
        {
            return db.ReservaDetalles;
        }

        // GET: api/ReservaDetalles/5
        [ResponseType(typeof(ReservaDetalle))]
        public IHttpActionResult GetReservaDetalle(int id)
        {
            ReservaDetalle reservaDetalle = db.ReservaDetalles.Find(id);
            if (reservaDetalle == null)
            {
                return NotFound();
            }

            return Ok(reservaDetalle);
        }

        // PUT: api/ReservaDetalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservaDetalle(int id, ReservaDetalle reservaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservaDetalle.Id)
            {
                return BadRequest();
            }

            db.Entry(reservaDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaDetalleExists(id))
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

        // POST: api/ReservaDetalles
        [ResponseType(typeof(ReservaDetalle))]
        public IHttpActionResult PostReservaDetalle(ReservaDetalle reservaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReservaDetalles.Add(reservaDetalle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservaDetalle.Id }, reservaDetalle);
        }

        // DELETE: api/ReservaDetalles/5
        [ResponseType(typeof(ReservaDetalle))]
        public IHttpActionResult DeleteReservaDetalle(int id)
        {
            ReservaDetalle reservaDetalle = db.ReservaDetalles.Find(id);
            if (reservaDetalle == null)
            {
                return NotFound();
            }

            db.ReservaDetalles.Remove(reservaDetalle);
            db.SaveChanges();

            return Ok(reservaDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaDetalleExists(int id)
        {
            return db.ReservaDetalles.Count(e => e.Id == id) > 0;
        }
    }
}
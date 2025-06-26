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
    public class DetalleFacturasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/DetalleFacturas
        public IQueryable<DetalleFactura> GetDetalleFacturas()
        {
            return db.DetalleFacturas;
        }

        // GET: api/DetalleFacturas/5
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult GetDetalleFactura(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return Ok(detalleFactura);
        }

        // PUT: api/DetalleFacturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetalleFactura(int id, DetalleFactura detalleFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalleFactura.Id)
            {
                return BadRequest();
            }

            db.Entry(detalleFactura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturaExists(id))
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

        // POST: api/DetalleFacturas
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult PostDetalleFactura(DetalleFactura detalleFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetalleFacturas.Add(detalleFactura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalleFactura.Id }, detalleFactura);
        }

        // DELETE: api/DetalleFacturas/5
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult DeleteDetalleFactura(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            db.DetalleFacturas.Remove(detalleFactura);
            db.SaveChanges();

            return Ok(detalleFactura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetalleFacturaExists(int id)
        {
            return db.DetalleFacturas.Count(e => e.Id == id) > 0;
        }
    }
}
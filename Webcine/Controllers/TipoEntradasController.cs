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
    public class TipoEntradasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/TipoEntradas
        public IQueryable<TipoEntrada> GetTipoEntradas()
        {
            return db.TipoEntradas;
        }

        // GET: api/TipoEntradas/5
        [ResponseType(typeof(TipoEntrada))]
        public IHttpActionResult GetTipoEntrada(int id)
        {
            TipoEntrada tipoEntrada = db.TipoEntradas.Find(id);
            if (tipoEntrada == null)
            {
                return NotFound();
            }

            return Ok(tipoEntrada);
        }

        // PUT: api/TipoEntradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoEntrada(int id, TipoEntrada tipoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEntrada.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoEntrada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEntradaExists(id))
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

        // POST: api/TipoEntradas
        [ResponseType(typeof(TipoEntrada))]
        public IHttpActionResult PostTipoEntrada(TipoEntrada tipoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoEntradas.Add(tipoEntrada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoEntrada.Id }, tipoEntrada);
        }

        // DELETE: api/TipoEntradas/5
        [ResponseType(typeof(TipoEntrada))]
        public IHttpActionResult DeleteTipoEntrada(int id)
        {
            TipoEntrada tipoEntrada = db.TipoEntradas.Find(id);
            if (tipoEntrada == null)
            {
                return NotFound();
            }

            db.TipoEntradas.Remove(tipoEntrada);
            db.SaveChanges();

            return Ok(tipoEntrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoEntradaExists(int id)
        {
            return db.TipoEntradas.Count(e => e.Id == id) > 0;
        }
    }
}
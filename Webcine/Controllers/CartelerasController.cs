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
    public class CartelerasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Carteleras
        public IQueryable<Cartelera> GetCarteleras()
        {
            return db.Carteleras;
        }

        // GET: api/Carteleras/5
        [ResponseType(typeof(Cartelera))]
        public IHttpActionResult GetCartelera(int id)
        {
            Cartelera cartelera = db.Carteleras.Find(id);
            if (cartelera == null)
            {
                return NotFound();
            }

            return Ok(cartelera);
        }

        // PUT: api/Carteleras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartelera(int id, Cartelera cartelera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartelera.Id)
            {
                return BadRequest();
            }

            db.Entry(cartelera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteleraExists(id))
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

        // POST: api/Carteleras
        [ResponseType(typeof(Cartelera))]
        public IHttpActionResult PostCartelera(Cartelera cartelera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carteleras.Add(cartelera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartelera.Id }, cartelera);
        }

        // DELETE: api/Carteleras/5
        [ResponseType(typeof(Cartelera))]
        public IHttpActionResult DeleteCartelera(int id)
        {
            Cartelera cartelera = db.Carteleras.Find(id);
            if (cartelera == null)
            {
                return NotFound();
            }

            db.Carteleras.Remove(cartelera);
            db.SaveChanges();

            return Ok(cartelera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarteleraExists(int id)
        {
            return db.Carteleras.Count(e => e.Id == id) > 0;
        }
    }
}
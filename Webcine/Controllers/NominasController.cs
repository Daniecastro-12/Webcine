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
    public class NominasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Nominas
        public IQueryable<Nomina> GetNominas()
        {
            return db.Nominas;
        }

        // GET: api/Nominas/5
        [ResponseType(typeof(Nomina))]
        public IHttpActionResult GetNomina(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return NotFound();
            }

            return Ok(nomina);
        }

        // PUT: api/Nominas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNomina(int id, Nomina nomina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nomina.Id)
            {
                return BadRequest();
            }

            db.Entry(nomina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(id))
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

        // POST: api/Nominas
        [ResponseType(typeof(Nomina))]
        public IHttpActionResult PostNomina(Nomina nomina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nominas.Add(nomina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nomina.Id }, nomina);
        }

        // DELETE: api/Nominas/5
        [ResponseType(typeof(Nomina))]
        public IHttpActionResult DeleteNomina(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return NotFound();
            }

            db.Nominas.Remove(nomina);
            db.SaveChanges();

            return Ok(nomina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NominaExists(int id)
        {
            return db.Nominas.Count(e => e.Id == id) > 0;
        }
    }
}
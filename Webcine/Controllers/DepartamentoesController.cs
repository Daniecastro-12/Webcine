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
    public class DepartamentoesController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Departamentoes
        public IQueryable<Departamento> GetDepartamento()
        {
            return db.Departamento;
        }

        // GET: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult GetDepartamento(int id)
        {
            Departamento departamento = db.Departamento.Find(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // PUT: api/Departamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartamento(int id, Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departamento.Id)
            {
                return BadRequest();
            }

            db.Entry(departamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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

        // POST: api/Departamentoes
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult PostDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departamento.Add(departamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departamento.Id }, departamento);
        }

        // DELETE: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult DeleteDepartamento(int id)
        {
            Departamento departamento = db.Departamento.Find(id);
            if (departamento == null)
            {
                return NotFound();
            }

            db.Departamento.Remove(departamento);
            db.SaveChanges();

            return Ok(departamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentoExists(int id)
        {
            return db.Departamento.Count(e => e.Id == id) > 0;
        }
    }
}
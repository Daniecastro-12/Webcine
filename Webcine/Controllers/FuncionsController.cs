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
    public class FuncionsController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Funcions
        public IQueryable<Funcion> GetFunciones()
        {
            return db.Funciones;
        }

        // GET: api/Funcions/5
        [ResponseType(typeof(Funcion))]
        public IHttpActionResult GetFuncion(int id)
        {
            Funcion funcion = db.Funciones.Find(id);
            if (funcion == null)
            {
                return NotFound();
            }

            return Ok(funcion);
        }

        // PUT: api/Funcions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncion(int id, Funcion funcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcion.Id)
            {
                return BadRequest();
            }

            db.Entry(funcion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionExists(id))
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

        // POST: api/Funcions
        [ResponseType(typeof(Funcion))]
        public IHttpActionResult PostFuncion(Funcion funcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funciones.Add(funcion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcion.Id }, funcion);
        }

        // DELETE: api/Funcions/5
        [ResponseType(typeof(Funcion))]
        public IHttpActionResult DeleteFuncion(int id)
        {
            Funcion funcion = db.Funciones.Find(id);
            if (funcion == null)
            {
                return NotFound();
            }

            db.Funciones.Remove(funcion);
            db.SaveChanges();

            return Ok(funcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionExists(int id)
        {
            return db.Funciones.Count(e => e.Id == id) > 0;
        }
    }
}
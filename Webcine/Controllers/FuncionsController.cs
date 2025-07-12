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
    public class FuncionsController : ApiController
    {
        private MiDbContext db = new MiDbContext();



        //FUNCION POR GENERO DE PELICULA
        [HttpGet]
        [Route("api/funciones/por-genero")]
        [SwaggerOperation("GetFuncionesPorGenero")]
        public IHttpActionResult GetFuncionesPorGenero(string genero)
        {
            var funciones = db.Funciones
                              .Include("Pelicula")
                              .Include("Sala")
                              .Where(f => f.Pelicula.Genero == genero)
                              .Select(f => new
                              {
                                  FuncionId = f.Id,
                                  FechaHora = f.FechaHora,
                                  PrecioEntrada = f.PrecioEntrada,

                                  Pelicula = new
                                  {
                                      Titulo = f.Pelicula.Titulo,
                                      Genero = f.Pelicula.Genero,
                                      Clasificacion = f.Pelicula.Clasificacion
                                  },

                                  Sala = new
                                  {
                                      Nombre = f.Sala.Nombre,
                                      Tipo = f.Sala.Tipo
                                  }
                              })
                              .ToList();

            return Ok(funciones);
        }



        //FUNCIONES POR RANGO DE FECHAS
        [HttpGet]
        [Route("api/funciones/por-fecha")]
        [SwaggerOperation("GetFuncionesPorFecha")]
        public IHttpActionResult GetFuncionesPorFecha(DateTime desde, DateTime hasta)
        {
            var funciones = db.Funciones
                              .Include("Pelicula")
                              .Where(f => f.FechaHora >= desde && f.FechaHora <= hasta)
                              .Select(f => new
                              {
                                  FuncionId = f.Id,
                                  FechaHora = f.FechaHora,
                                  TituloPelicula = f.Pelicula.Titulo,
                                  Duracion = f.Pelicula.Duracion
                              })
                              .ToList();

            return Ok(funciones);
        }




        //FUNCION POR TIPO DE SALA
        [HttpGet]
        [Route("api/funciones/por-tipo-sala")]
        [SwaggerOperation("GetFuncionesPorTipoSala")]
        public IHttpActionResult GetFuncionesPorTipoSala(string tipoSala)
        {
            var funciones = db.Funciones
                              .Include("Sala")
                              .Include("Pelicula")
                              .Where(f => f.Sala.Tipo == tipoSala)
                              .Select(f => new
                              {
                                  FuncionId = f.Id,
                                  FechaHora = f.FechaHora,
                                  AsientosDisponibles = f.AsientosDisponibles,

                                  Sala = new
                                  {
                                      Nombre = f.Sala.Nombre,
                                      Tipo = f.Sala.Tipo,
                                      Capacidad = f.Sala.Capacidad
                                  },

                                  Pelicula = new
                                  {
                                      Titulo = f.Pelicula.Titulo
                                  }
                              })
                              .ToList();

            return Ok(funciones);
        }







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
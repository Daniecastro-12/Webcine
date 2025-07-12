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
    public class PeliculasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        //funciona


        //TODASD LAS PELICULAS CON NUMEROS DE FUNCIONES PROGRAMADA
        [HttpGet]
        [Route("api/peliculas/con-funciones")]
        [SwaggerOperation("GetPeliculasConCantidadFunciones")]
        public IHttpActionResult GetPeliculasConCantidadFunciones()
        {
            var peliculas = db.Peliculas
                              .Select(p => new
                              {
                                  PeliculaId = p.Id,
                                  Titulo = p.Titulo,
                                  Genero = p.Genero,
                                  Clasificacion = p.Clasificacion,
                                  FuncionesProgramadas = p.Funciones.Count
                              })
                              .ToList();

            return Ok(peliculas);
        }

        //PELICULAS FILTRADAS POR EL IDIOPMA Y CLASIFICACION
        [HttpGet]
        [Route("api/peliculas/filtro")]
        [SwaggerOperation("GetPeliculasPorIdiomaClasificacion")]
        public IHttpActionResult GetPeliculasPorIdiomaClasificacion(string idioma, string clasificacion)
        {
            var peliculas = db.Peliculas
                              .Where(p => p.Idioma == idioma && p.Clasificacion == clasificacion)
                              .Select(p => new
                              {
                                  PeliculaId = p.Id,
                                  Titulo = p.Titulo,
                                  Duracion = p.Duracion,
                                  FechaEstreno = p.FechaEstreno
                              })
                              .ToList();

            return Ok(peliculas);
        }


        //PELICULAS CON FUNCIONES PROXIMAS
        [HttpGet]
        [Route("api/peliculas/proximas-funciones")]
        [SwaggerOperation("GetPeliculasConFuncionesProximas")]
        public IHttpActionResult GetPeliculasConFuncionesProximas(DateTime desde)
        {
            var peliculas = db.Peliculas
                              .Where(p => p.Funciones.Any(f => f.FechaHora >= desde))
                              .Select(p => new
                              {
                                  PeliculaId = p.Id,
                                  Titulo = p.Titulo,
                                  Genero = p.Genero,

                                  Funciones = p.Funciones
                                               .Where(f => f.FechaHora >= desde)
                                               .Select(f => new
                                               {
                                                   FechaHora = f.FechaHora,
                                                   SalaId = f._salaId,
                                                   PrecioEntrada = f.PrecioEntrada
                                               }).ToList()
                              })
                              .ToList();

            return Ok(peliculas);
        }

        // GET: api/Peliculas
        public IQueryable<Pelicula> GetPeliculas()
        {
            return db.Peliculas;
        }

        // GET: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult GetPelicula(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // PUT: api/Peliculas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPelicula(int id, Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pelicula.Id)
            {
                return BadRequest();
            }

            db.Entry(pelicula).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
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

        // POST: api/Peliculas
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult PostPelicula(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Peliculas.Add(pelicula);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pelicula.Id }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult DeletePelicula(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            db.Peliculas.Remove(pelicula);
            db.SaveChanges();

            return Ok(pelicula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeliculaExists(int id)
        {
            return db.Peliculas.Count(e => e.Id == id) > 0;
        }
    }
}
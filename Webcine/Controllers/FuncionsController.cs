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
using Webcine.DTOs;
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


       [HttpGet]
        [Route("api/funciones/por-pelicula")]
        public IHttpActionResult GetFuncionesPorPelicula(int peliculaId)
        {
            var funciones = db.Funciones
                .Where(f => f._peliculaId == peliculaId)
                .Select(f => new {
                    FuncionId = f.Id,
                    FechaHora = f.FechaHora,
                    PrecioEntrada = f.PrecioEntrada,
                    AsientosDisponibles = f.AsientosDisponibles,
                    Sala = new
                    {
                        Nombre = f.Sala.Nombre,
                        Tipo = f.Sala.Tipo
                    }
                })
                .ToList();

            return Ok(funciones);
        }


        [HttpGet]
        [Route("api/funciones/por-pelicula-externa")]
        public IHttpActionResult GetFuncionesPorPeliculaExterna(int idExterna)
        {
            // Busca la película por el id externo (TMDb)
            var pelicula = db.Peliculas.FirstOrDefault(p => p.IdExterna == idExterna);
            if (pelicula == null)
                return NotFound();

            // Busca las funciones usando el Id local
            var funciones = db.Funciones
                              .Include(f => f.Sala)
                              .Where(f => f._peliculaId == pelicula.Id)
                              .Select(f => new {
                                  FuncionId = f.Id,
                                  FechaHora = f.FechaHora,
                                  PrecioEntrada = f.PrecioEntrada,
                                  AsientosDisponibles = f.AsientosDisponibles,
                                  Sala = new
                                  {
                                      Nombre = f.Sala.Nombre,
                                      Tipo = f.Sala.Tipo
                                  }
                              })
                              .ToList();

            return Ok(funciones);
        }





        [HttpPost]
        [Route("api/funciones/ocupar-asientos")]
        public IHttpActionResult OcuparAsientos([FromBody] OcuparAsientosRequest req)
        {
            if (req == null || req.IdsAsientos == null || !req.IdsAsientos.Any())
            {
                System.Diagnostics.Debug.WriteLine("No se recibieron IDs de asientos para ocupar.");
                return BadRequest("No se recibieron IDs de asientos.");
            }

            foreach (var id in req.IdsAsientos)
            {
                var asiento = db.Asientos.Find(id);
                if (asiento != null)
                {
                    if (asiento.Disponible)
                    {
                        asiento.Disponible = false;
                        System.Diagnostics.Debug.WriteLine($"Asiento {asiento.Id} marcado como ocupado.");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Asiento {asiento.Id} ya estaba ocupado.");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"No se encontró el asiento con Id {id}.");
                }
            }

            db.SaveChanges();
            return Ok();
        }

        public class OcuparAsientosRequest
        {
            public List<int> IdsAsientos { get; set; }
        }






        [HttpGet]
        [Route("api/funciones/{id}/asientos")]
        public IHttpActionResult GetAsientosPorFuncion(int id)
        {
            var funcion = db.Funciones
                .Include(f => f.Asientos)
                .FirstOrDefault(f => f.Id == id);
            if (funcion == null) return NotFound();

            var lista = funcion.Asientos
                .Select(a => new AsientoDTO
                {
                    Id = a.Id,
                    Fila = a.Fila,
                    Columna = a.Columna,
                    Disponible = a.Disponible
                })
                .ToList();
            return Ok(lista);
        }


        // POST api/funciones/{id}/asientos/generar
        [HttpPost]
        [Route("{id}/asientos/generar")]
        public IHttpActionResult GenerarAsientos(int id)
        {
            // 1) Busca la función (incluye la sala para obtener capacidad)
            var funcion = db.Funciones
                           .Include(f => f.Sala)
                           .FirstOrDefault(f => f.Id == id);
            if (funcion == null)
                return NotFound();

            // 2) Define filas y columnas (aquí usamos A–J y
            //    columnas según la capacidad / número de filas)
            var filas = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            int colsCount = funcion.Sala.Capacidad / filas.Length;
            var columnas = Enumerable.Range(1, colsCount);

            // 3) Crea los objetos Asiento
            var nuevos = (from fila in filas
                          from col in columnas
                          select new Asiento
                          {
                              SalaId = funcion._salaId,
                              FuncionId = funcion.Id,
                              Fila = fila,
                              Columna = col,
                              Disponible = true
                          }).ToList();

            // 4) Inserta en la base y guarda
            db.Asientos.AddRange(nuevos);
            db.SaveChanges();

            // 5) Mapea a DTO y devuelve
            var dto = nuevos.Select(a => new AsientoDTO
            {
                Id = a.Id,
                Fila = a.Fila,
                Columna = a.Columna,
                Disponible = a.Disponible
            });
            return Ok(dto);
        }






        [HttpPost]
        [Route("api/funcionesdto")]
        public IHttpActionResult PostFuncionDTO(FuncionDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcion = new Funcion
            {
                _peliculaId = dto._peliculaId,
                _salaId = dto._salaId,
                _fechaHora = dto._fechaHora,
                _precioEntrada = dto._precioEntrada,
                _asientosDisponibles = dto._asientosDisponibles
            };

            db.Funciones.Add(funcion);
            db.SaveChanges();

            return Ok(funcion);
        }

        [ResponseType(typeof(Funcion))]
        public IHttpActionResult GetFuncionDTO(int id)
        {
            var funcion = db.Funciones.Find(id);
            if (funcion == null) return NotFound();

            var dto = new FuncionDTO
            {
                _peliculaId = funcion._peliculaId,
                _salaId = funcion._salaId,
                _fechaHora = funcion._fechaHora,
                _precioEntrada = funcion._precioEntrada,
                _asientosDisponibles = funcion._asientosDisponibles
            };
            return Ok(dto);
        }


        [HttpGet]
        [Route("api/funciones/por-pelicula-detalle")]
        public IHttpActionResult GetFuncionesPorPeliculaAgrupado(int idPelicula)
        {
            var funciones = db.Funciones
                .Where(f => f._peliculaId == idPelicula)
                .Include(f => f.Sala)
                .Select(f => new {
                    SalaId = f.Sala.Id,
                    SalaNombre = f.Sala.Nombre,
                    SalaTipo = f.Sala.Tipo,
                    SalaUbicacion = f.Sala.Ubicacion,
                    FuncionId = f.Id,
                    FechaHora = f.FechaHora,
                    PrecioEntrada = f.PrecioEntrada,
                    AsientosDisponibles = f.AsientosDisponibles
                }).ToList();

            var agrupado = funciones
                .GroupBy(f => new { f.SalaId, f.SalaNombre, f.SalaTipo, f.SalaUbicacion })
                .Select(g => new {
                    SalaId = g.Key.SalaId,
                    Nombre = g.Key.SalaNombre,
                    Tipo = g.Key.SalaTipo,
                    Ubicacion = g.Key.SalaUbicacion,
                    Funciones = g.Select(x => new {
                        x.FuncionId,
                        x.FechaHora,
                        x.PrecioEntrada,
                        x.AsientosDisponibles
                    })
                });

            return Ok(agrupado);
        }



        
        /*Metodo para compra los boletos*/
        [HttpGet]
        [Route("api/funciones/detalle")]
        public IHttpActionResult GetDetalleFuncion(int id)
        {
            var funcion = db.Funciones
                .Include(f => f.Sala)
                .Include(f => f.Pelicula)
                .FirstOrDefault(f => f.Id == id);

            if (funcion == null)
                return NotFound();

            return Ok(new
            {
                PeliculaId = funcion._peliculaId,
                Pelicula = funcion.Pelicula.Titulo,
                Sala = funcion.Sala.Nombre,
                FechaHora = funcion._fechaHora,
                Clasificacion = funcion.Pelicula.Clasificacion,
                IdExterna = funcion.Pelicula.IdExterna   
            });
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
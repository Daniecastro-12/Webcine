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
using Webcine.Models;
using WebCine.Models;

namespace Webcine.Controllers
{
    public class FuncionTipoEntradasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/FuncionTipoEntradas
        public IQueryable<FuncionTipoEntrada> GetFuncionTipoEntradas()
        {
            return db.FuncionTipoEntradas;
        }



        [HttpGet]
        [Route("api/funcion-tipoentrada/por-funcion/{id}")]
        public IHttpActionResult GetPorFuncion(int id)
        {
            var tipos = db.FuncionTipoEntradas
                          .Where(x => x.FuncionId == id)
                          .Select(x => new {
                              Tipo = x.TipoEntrada.Nombre,
                              Precio = x.TipoEntrada.PrecioBase,
                              Servicio = x.TipoEntrada.CostoServicio,
                              Disponibles = x.Disponibles
                          }).ToList();

            return Ok(tipos);
        }


        [HttpPost]
        [Route("api/funcion-tipo-entradas")]
        public IHttpActionResult PostFuncionTipoEntradas(FuncionTipoEntradaDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            // Mapear DTO al modelo real si es necesario
            var funcionTipoEntrada = new FuncionTipoEntrada
            {
                FuncionId = dto.FuncionId,
                TipoEntradaId = dto.TipoEntradaId,
                Disponibles = dto.Disponibles
            };

            db.FuncionTipoEntradas.Add(funcionTipoEntrada);
            db.SaveChanges();

            return Ok();
        }




        // GET: api/FuncionTipoEntradas/5
        [ResponseType(typeof(FuncionTipoEntrada))]
        public IHttpActionResult GetFuncionTipoEntrada(int id)
        {
            FuncionTipoEntrada funcionTipoEntrada = db.FuncionTipoEntradas.Find(id);
            if (funcionTipoEntrada == null)
            {
                return NotFound();
            }

            return Ok(funcionTipoEntrada);
        }

        // PUT: api/FuncionTipoEntradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionTipoEntrada(int id, FuncionTipoEntrada funcionTipoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionTipoEntrada.Id)
            {
                return BadRequest();
            }

            db.Entry(funcionTipoEntrada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionTipoEntradaExists(id))
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

        // POST: api/FuncionTipoEntradas
        [ResponseType(typeof(FuncionTipoEntrada))]
        public IHttpActionResult PostFuncionTipoEntrada(FuncionTipoEntrada funcionTipoEntrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FuncionTipoEntradas.Add(funcionTipoEntrada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcionTipoEntrada.Id }, funcionTipoEntrada);
        }

        // DELETE: api/FuncionTipoEntradas/5
        [ResponseType(typeof(FuncionTipoEntrada))]
        public IHttpActionResult DeleteFuncionTipoEntrada(int id)
        {
            FuncionTipoEntrada funcionTipoEntrada = db.FuncionTipoEntradas.Find(id);
            if (funcionTipoEntrada == null)
            {
                return NotFound();
            }

            db.FuncionTipoEntradas.Remove(funcionTipoEntrada);
            db.SaveChanges();

            return Ok(funcionTipoEntrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionTipoEntradaExists(int id)
        {
            return db.FuncionTipoEntradas.Count(e => e.Id == id) > 0;
        }
    }
}
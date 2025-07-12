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
    public class EmpleadoesController : ApiController
    {
        private MiDbContext db = new MiDbContext();



        [HttpGet]
        [Route("api/empleados/info")]
        [SwaggerOperation("GetEmpleadosConDepartamento")]
        public IHttpActionResult GetEmpleadosConDepartamento()
        {
            var empleados = db.Empleados
                              .Include("Departamento")
                              .Select(e => new
                              {
                                  EmpleadoId = e.Id,
                                  NombreCompleto = e.Nombre + " " + e.Apellido,
                                  Puesto = e.Puesto,
                                  Sueldo = e.Sueldo,
                                  FechaContratacion = e.FlechaContratacion,

                                  Departamento = new
                                  {
                                      DepartamentoId = e.departamento.Id,
                                      Nombre = e.departamento.Nombre
                                  }
                              })
                              .ToList();

            return Ok(empleados);
        }


        //FILTRADO POR DEPARTAMENTO
        [HttpGet]
        [Route("api/empleados/por-departamento")]
        [SwaggerOperation("GetEmpleadosPorDepartamento")]
        public IHttpActionResult GetEmpleadosPorDepartamento(int departamentoId)
        {
            var empleados = db.Empleados
                              .Where(e => e._departamentoId == departamentoId)
                              .Select(e => new
                              {
                                  EmpleadoId = e.Id,
                                  Nombre = e.Nombre,
                                  Apellido = e.Apellido,
                                  Puesto = e.Puesto
                              })
                              .ToList();

            return Ok(empleados);
        }





        //empleaoo con su historial de pagos
        [HttpGet]
        [Route("api/empleados/nomina")]
        [SwaggerOperation("GetEmpleadosConPagos")]
        public IHttpActionResult GetEmpleadosConPagos()
        {
            var empleados = db.Empleados
                              .Include("Pagos")
                              .Select(e => new
                              {
                                  EmpleadoId = e.Id,
                                  NombreCompleto = e.Nombre + " " + e.Apellido,
                                  Puesto = e.Puesto,

                                  Pagos = e._pagos.Select(p => new
                                  {
                                      PagoId = p.Id,
                                      Monto = p.Monto,
                                      FechaPago = p.FechaPago
                                  }).ToList()
                              })
                              .ToList();

            return Ok(empleados);
        }






        // GET: api/Empleadoes
        public IQueryable<Empleado> GetEmpleados()
        {
            return db.Empleados;
        }

        // GET: api/Empleadoes/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // PUT: api/Empleadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.Id)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados.Add(empleado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleados.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.Empleados.Count(e => e.Id == id) > 0;
        }
    }
}
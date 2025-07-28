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
    public class FacturasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: api/Facturas
        public IQueryable<Factura> GetFacturas()
        {
            return db.Facturas;
        }




        [HttpPost]
        [Route("api/facturas/registrar-compra")]
        public IHttpActionResult RegistrarCompra([FromBody] FacturaRequestDTO request)
        {
            if (request == null || request.Cliente == null)
                return BadRequest("Faltan los datos del cliente.");

            var factura = new Factura
            {
                NombreCliente = request.Cliente.Nombre,
                ApellidoCliente = request.Cliente.Apellido,
                EmailCliente = request.Cliente.Email,
                Fecha = DateTime.Now,
                Total = request.Total,
                Detalles = new List<DetalleFactura>()
            };

            foreach (var d in request.Detalles)
            {
                factura.Detalles.Add(new DetalleFactura
                {
                    Tipo = d.Tipo,
                    Descripcion = d.Descripcion,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                });
            }

            db.Facturas.Add(factura);
            db.SaveChanges();

            // Generar QR y enviar correo como antes...
            string resumenQR = $"Factura #{factura.Id}\nCliente: {factura.NombreCliente} {factura.ApellidoCliente}\nTotal: L {factura.Total}\nDetalles:\n" +
                string.Join("\n", factura.Detalles.Select(x => $"{x.Tipo}: {x.Descripcion} x{x.Cantidad} (L {x.Subtotal})"));

            byte[] qrBytes = QrHelper.GenerarQrComoPng(resumenQR);

            string cuerpoMail = $"¡Gracias por tu compra!\n\n{resumenQR}\n\nAdjunto tu QR para presentar en taquilla.";
            EmailHelper.EnviarCorreoConQR(factura.EmailCliente, "Tu compra en el cine", cuerpoMail, qrBytes);

            return Ok(new { success = true, facturaId = factura.Id });
        }















        // GET: api/Facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFactura(int id)
        {
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // PUT: api/Facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactura(int id, Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.Id)
            {
                return BadRequest();
            }

            db.Entry(factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        [ResponseType(typeof(Factura))]
        public IHttpActionResult PostFactura(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facturas.Add(factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult DeleteFactura(int id)
        {
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            db.Facturas.Remove(factura);
            db.SaveChanges();

            return Ok(factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturaExists(int id)
        {
            return db.Facturas.Count(e => e.Id == id) > 0;
        }
    }
}
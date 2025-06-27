using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebCine.Models
{
    /// <summary>
    /// Contexto de base de datos para la aplicación WebCine.
    /// Gestiona las entidades y la configuración de Entity Framework.
    /// </summary>
    public class MiDbContext : DbContext
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la cadena de conexión especificada.
        /// </summary>
        public MiDbContext() : base("name=MyDbConnectionString")
        {
            // Opcional: Configuración adicional
            Database.SetInitializer<MiDbContext>(null); // Desactiva inicializaciones automáticas
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Cartelera> Carteleras { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

        /// <summary>
        /// Configura el modelo de entidades y sus relaciones.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos de Entity Framework.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


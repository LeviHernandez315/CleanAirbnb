using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
     public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options) { }

        //Entities' DbSets
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; } 
        public DbSet<Empresa> Empresa { get; set; }  
        public DbSet<Propiedad> Propiedades { get; set; }  
        public DbSet<Vehiculo> Vehiculos { get; set; } 
        public DbSet<AreaTrabajo> AreasTrabajo { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<DatosPago> DatosPagos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<EstadoReserva> EstadosReserva { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<PuestoTrabajo> PuestosTrabajo { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<TipoVehiculo> TiposVehiculo { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }

        //Aggregates' DbSets
        public DbSet<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReseñaVehiculo> ReseñasVehiculo { get; set; }
        public DbSet<ReservaVehiculo> ReservasVehiculo { get; set; }
        public DbSet<ReseñaPropiedad> ReseñasPropiedad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DNI will be the Primary Key of the Persona table 
            modelBuilder.Entity<Persona>().HasKey(p => p.DNI);

            //Usuarios' Foreign keys
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.Dni)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            //Empleados' Foreign keys
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Persona)
                .WithMany()
                .HasForeignKey(e => e.Dni)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.PuestoTrabajo)
                .WithMany()
                .HasForeignKey(e => e.PuestoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Direccion)
                .WithMany()
                .HasForeignKey(e => e.DireccionId)
                .OnDelete(DeleteBehavior.Restrict);

            //save a decimal field in the Empleado table
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasColumnType("decimal(18,2)");

            //EncabezadoFactura's Foreign keys
            modelBuilder.Entity<EncabezadoFactura>()
                .HasOne(ef => ef.Usuario)
                .WithMany()
                .HasForeignKey(ef => ef.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EncabezadoFactura>()
                .HasOne(ef => ef.Reserva)
                .WithMany()
                .HasForeignKey(ef => ef.IdReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EncabezadoFactura>()
                .HasOne(ef => ef.Empresa)
                .WithMany()
                .HasForeignKey(ef => ef.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EncabezadoFactura>()
                .HasOne(ef => ef.Sucursal)
                .WithMany()
                .HasForeignKey(ef => ef.IdSucursal)
                .OnDelete(DeleteBehavior.Restrict);

            //Propiedad's Foreign keys
            modelBuilder.Entity<Propiedad>()
                .HasOne(pr => pr.Direccion)
                .WithMany()
                .HasForeignKey(pr => pr.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Propiedad>()
                .HasOne(pr => pr.Anfitrion)
                .WithMany()
                .HasForeignKey(pr => pr.IdAnfitrion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Propiedad>()
                .HasOne(pr => pr.EstadoReserva)
                .WithMany()
                .HasForeignKey(pr => pr.IdEstadoReserva)
                .OnDelete(DeleteBehavior.Restrict);

            //save decimal fields in the Propiedad table
            modelBuilder.Entity<Propiedad>()
                .Property(e => e.MediaValoracion)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Propiedad>()
                .Property(e => e.PrecioPorNoche)
                .HasColumnType("decimal(18,2)");

            //Propiedad's Foreign keys
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Propiedad)
                .WithMany()
                .HasForeignKey(r => r.IdPropiedad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Huesped)
                .WithMany()
                .HasForeignKey(r => r.IdHuesped)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.EmpleadoLogistica)
                .WithMany()
                .HasForeignKey(r => r.IdEmpleadoLogistica)
                .OnDelete(DeleteBehavior.Restrict);

            //save decimal fields in the Reserva table
            modelBuilder.Entity<Reserva>()
                .Property(e => e.Adelanto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(e => e.MontoImpuesto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(e => e.PrecioEstadia)
                .HasColumnType("decimal(18,2)");

            //vehiculo's Foreign keys
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Modelo)
                .WithMany()
                .HasForeignKey(v => v.IdModelo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Direccion)
                .WithMany()
                .HasForeignKey(v => v.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.TipoVehiculo)
                .WithMany()
                .HasForeignKey(v => v.IdTipoVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.EstadoReserva)
                .WithMany()
                .HasForeignKey(v => v.IdEstadoReserva)
                .OnDelete(DeleteBehavior.Restrict);

            //save a decimal field in the Reserva table
            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.PrecioDia)
                .HasColumnType("decimal(18,2)");

            //Ciudad's Foreign keys
            modelBuilder.Entity<Ciudad>()
                .HasOne(c => c.Departamento)
                .WithMany()
                .HasForeignKey(c => c.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            //DatosPago's Foreign keys
            modelBuilder.Entity<DatosPago>()
                .HasOne(dp => dp.Reserva)
                .WithMany()
                .HasForeignKey(dp => dp.IdReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DatosPago>()
                .HasOne(dp => dp.MetodoPago)
                .WithMany()
                .HasForeignKey(dp => dp.IdMetodoPago)
                .OnDelete(DeleteBehavior.Restrict);

            //Departamentos' Foreign keys
            modelBuilder.Entity<Departamento>()
                .HasOne(d => d.Pais)
                .WithMany()
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.Restrict);

            //DetalleFactura's Foreign keys
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.EncabezadoFactura)
                .WithMany()
                .HasForeignKey(df => df.IdEncabezadoFactura)
                .OnDelete(DeleteBehavior.Restrict);

            //save decimal fields in the Reserva table
            modelBuilder.Entity<DetalleFactura>()
                .Property(e => e.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DetalleFactura>()
                .Property(e => e.Total)
                .HasColumnType("decimal(18,2)");

            //Direccion's Foreign keys
            modelBuilder.Entity<Direccion>()
                .HasOne(drc => drc.Ciudad)
                .WithMany()
                .HasForeignKey(drc => drc.IdCiudad)
                .OnDelete(DeleteBehavior.Restrict);

            //Modelo's Foreign keys
            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany()
                .HasForeignKey(m => m.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

            //PuestoTrabajo's Foreign keys
            modelBuilder.Entity<PuestoTrabajo>()
                .HasOne(pt => pt.Area)
                .WithMany()
                .HasForeignKey(pt => pt.IdArea)
                .OnDelete(DeleteBehavior.Restrict);

            //ReseñaPropiedad's Foreign keys
            modelBuilder.Entity<ReseñaPropiedad>()
                .HasOne(rp => rp.UsuarioHuesped)
                .WithMany()
                .HasForeignKey(rp => rp.IdUsuarioHuesped)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReseñaPropiedad>()
                .HasOne(rp => rp.Propiedad)
                .WithMany()
                .HasForeignKey(rp => rp.IdPropiedad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReseñaPropiedad>()
                .HasOne(rp => rp.Valoracion)
                .WithMany()
                .HasForeignKey(rp => rp.IdValoracion)
                .OnDelete(DeleteBehavior.Restrict);

            //ReseñaVehiculo's Foreign keys
            modelBuilder.Entity<ReseñaVehiculo>()
                .HasOne(rv => rv.UsuarioHuesped)
                .WithMany()
                .HasForeignKey(rv => rv.IdUsuarioHuesped)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReseñaVehiculo>()
                .HasOne(rv => rv.Vehiculo)
                .WithMany()
                .HasForeignKey(rv => rv.IdVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReseñaVehiculo>()
                .HasOne(rv => rv.Valoracion)
                .WithMany()
                .HasForeignKey(rv => rv.IdValoracion)
                .OnDelete(DeleteBehavior.Restrict);

            //ReservaVehiculo's Foreign keys
            modelBuilder.Entity<ReservaVehiculo>()
                .HasOne(rvv => rvv.Vehiculo)
                .WithMany()
                .HasForeignKey(rvv => rvv.IdVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservaVehiculo>()
                .HasOne(rvv => rvv.Reserva)
                .WithMany()
                .HasForeignKey(rvv => rvv.IdReserva)
                .OnDelete(DeleteBehavior.Restrict);

            //save decimal fields in the Reserva table
            modelBuilder.Entity<ReservaVehiculo>()
                .Property(e => e.ImpuestoVehiculo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ReservaVehiculo>()
                .Property(e => e.PrecioVehiculo)
                .HasColumnType("decimal(18,2)");

            //Sucursal's Foreign keys
            modelBuilder.Entity<Sucursal>()
                .HasOne(s => s.Direccion)
                .WithMany()
                .HasForeignKey(s => s.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sucursal>()
                .HasOne(s => s.Empresa)
                .WithMany()
                .HasForeignKey(s => s.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            //Telefono's Foreign keys
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Persona)
                .WithMany()
                .HasForeignKey(t => t.IdPersona)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

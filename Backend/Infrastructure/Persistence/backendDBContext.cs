using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
     public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //DBSets de los AggregateRoots
        public DbSet<Empleado> Empleados { get; set; } // ya estan
        public DbSet<Empresa> Empresa { get; set; } // ya esta (No necesita)
        public DbSet<EncabezadoFactura> EncabezadoFacturas { get; set; } // ya esta 
        public DbSet<Propiedad> Propiedades { get; set; } // ya esta
        public DbSet<Reserva> Reservas { get; set; } // ya esta
        public DbSet<Vehiculo> Vehiculos { get; set; } // ya esta

        //DBSets de las Entities
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
        public DbSet<ReseñaPropiedad> ReseñasPropiedad { get; set; }
        public DbSet<ReseñaVehiculo> ReseñasVehiculo { get; set; }
        public DbSet<ReservaVehiculo> ReservasVehiculo { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<TipoVehiculo> TiposVehiculo { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Queremos que el DNI sea la Primary Key de la tabla Persona 
            modelBuilder.Entity<Persona>().HasKey(p => p.DNI);

            //Construir para la tabla Usuarios
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

            //Foreign Key para Empleado
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

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasColumnType("decimal(18,2)");

            //Empresa no tiene Foreign Key

            //Foreign Key EncabezadoFactura
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

            //Foreign key Propiedad
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

            modelBuilder.Entity<Propiedad>()
                .Property(e => e.MediaValoracion)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Propiedad>()
                .Property(e => e.PrecioPorNoche)
                .HasColumnType("decimal(18,2)");

            //Foreign Key Reserva
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

            modelBuilder.Entity<Reserva>()
                .Property(e => e.Adelanto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(e => e.MontoImpuesto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(e => e.PrecioEstadia)
                .HasColumnType("decimal(18,2)");

            //Foreign Key de Vehiculos
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

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.PrecioDia)
                .HasColumnType("decimal(18,2)");

            //Foreign Keys de las Entities
            //Foreign key de Ciudad
            modelBuilder.Entity<Ciudad>()
                .HasOne(c => c.Departamento)
                .WithMany()
                .HasForeignKey(c => c.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Foreign Key de DatosPago
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

            //Foreign Key de Departamentos
            modelBuilder.Entity<Departamento>()
                .HasOne(d => d.Pais)
                .WithMany()
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.Restrict);

            //Foreign Key de DetalleFactura
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(df => df.EncabezadoFactura)
                .WithMany()
                .HasForeignKey(df => df.IdEncabezadoFactura)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleFactura>()
                .Property(e => e.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DetalleFactura>()
                .Property(e => e.Total)
                .HasColumnType("decimal(18,2)");

            //Foreign Key de Direccion
            modelBuilder.Entity<Direccion>()
                .HasOne(drc => drc.Ciudad)
                .WithMany()
                .HasForeignKey(drc => drc.IdCiudad)
                .OnDelete(DeleteBehavior.Restrict);

            //Foreign Key de Modelo
            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany()
                .HasForeignKey(m => m.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

            //Foreign Key de PuestoTrabajo
            modelBuilder.Entity<PuestoTrabajo>()
                .HasOne(pt => pt.Area)
                .WithMany()
                .HasForeignKey(pt => pt.IdArea)
                .OnDelete(DeleteBehavior.Restrict);

            //Foreign Key de ReseñaPropiedad
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

            //Foreign Key de ReseñaVehiculo
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

            //Foreign Key de ReservaVehiculo
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

            modelBuilder.Entity<ReservaVehiculo>()
                .Property(e => e.ImpuestoVehiculo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ReservaVehiculo>()
                .Property(e => e.PrecioVehiculo)
                .HasColumnType("decimal(18,2)");

            //Foreign Key de Sucursal
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

            //Foreign Key de Telefono
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Persona)
                .WithMany()
                .HasForeignKey(t => t.IdPersona)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

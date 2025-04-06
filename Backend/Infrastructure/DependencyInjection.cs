using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Application.Services.Entidades;
using Infrastructure.Repositories.Entidades;
using Application.Services.AggregateRoots;
using Infrastructure.Repositories.AggregateRoots;


using Application.Interfaces.Entidades.CiudadInterfaces;
using Application.Interfaces.Entidades.DatosPagoInterfaces;
using Application.Interfaces.Entidades.DepartamentoInterfaces;
using Application.Interfaces.Entidades.DetalleFacturaInterfaces;
using Application.Interfaces.Entidades.DireccionInterfaces;
using Application.Interfaces.Entidades.EmpleadoInterfaces;
using Application.Interfaces.Entidades.EmpresaInterfaces;
using Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces;
using Application.Interfaces.Entidades.EstadoReservaInterfaces;

using Application.Interfaces.Entidades.PaisInterfaces;
using Application.Interfaces.Entidades.PersonaInterfaces;
using Application.Interfaces.Entidades.PropiedadInterfaces;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
using Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces;
using Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces;
using Application.Interfaces.AggregateRoots.ReservaInterfaces;
using Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces; 
using Application.Interfaces.Entidades.RolInterfaces;
using Application.Interfaces.Entidades.SucursalInterfaces;
using Application.Interfaces.Entidades.MarcaInterfaces;
using Application.Interfaces.Entidades.ModeloInterfaces;

/*
using Application.Interfaces.Entidades.TelefonoInterfaces;
using Application.Interfaces.Entidades.TipoVehiculoInterfaces;
using Application.Interfaces.Entidades.MarcaInterfaces;
using Application.Interfaces.Entidades.MetodoPagoInterfaces;
using Application.Interfaces.Entidades.ValoracionInterfaces;*/
using Application.Interfaces.Entidades.ModeloInterfaces; 
using Application.Interfaces.Entidades.UsuarioInterfaces;

using Application.Interfaces.Entidades.VehiculoInterfaces; 
// Repositories


using Infrastructure.Repositories;

using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            //los services.AddScoped de AreaTrabajo
            // services.AddScoped<IAreaTrabajoRepository, AreaTrabajoRepository>();
            //services.AddScoped<IAreaTrabajoService, AreaTrabajoService>();

             services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IRolService, RolService>();

           services.AddScoped<IAreaTrabajoRepository, AreaTrabajoRepository>();
            services.AddScoped<IAreaTrabajoService, AreaTrabajoService>();

            services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<ICiudadService, CiudadService>();

            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IPaisService, PaisService>();

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();

            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IDireccionService, DireccionService>();

            services.AddScoped<IPuestoTrabajoRepository, PuestoTrabajoRepository>();
            services.AddScoped<IPuestoTrabajoService, PuestoTrabajoService>();

            services.AddScoped<IDatosPagoRepository, DatosPagoRepository>();
            services.AddScoped<IDatosPagoService, DatosPagoService>();

           

            services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
            services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();

          

            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IEncabezadoFacturaRepository, EncabezadoFacturaRepository>();
            services.AddScoped<IEncabezadoFacturaService, EncabezadoFacturaService>();

            services.AddScoped<IEstadoReservaRepository, EstadoReservaRepository>();
            services.AddScoped<IEstadoReservaService, EstadoReservaService>();

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped <IMarcaService, MarcaService>();




            /*services.AddScoped<IMetodoPagoRepository, MetodPagoRepository>();
            services.AddScoped<IMetodoPagoService, MetodosPagoService>();*/

            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IModeloService, ModeloService>();
             


            services.AddScoped<IPropiedadRepository, PropiedadRepository>();
            services.AddScoped<IPropiedadService, PropiedadService>();

         

            services.AddScoped<IReseñaPropiedadRepository, ReseñaPropiedadRepository>();
            services.AddScoped<IReseñaPropiedadService, ReseñaPropiedadService>();

            services.AddScoped<IReseñaVehiculoRepository, ReseñaVehiculoRepository>();
            services.AddScoped<IReseñaVehiculoService, ReseñaVehiculoService>();

            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IReservaService, ReservaService>();

            services.AddScoped<IReservaVehiculoRepository, ReservaVehiculoRepository>();
            services.AddScoped<IReservaVehiculoService, ReservaVehiculoService>();


            services.AddScoped<ISucursalRepository, SucursalRepository>();
            services.AddScoped<ISucursalService, SucursalService>();
/*
            services.AddScoped<ITelefonoRepository, TelefonoRepository>();
            services.AddScoped<ITelefonoService, TelefonoService>();

            services.AddScoped<ITipoVehiculoRepository, TipoVehiculoRepository>();
            services.AddScoped<ITipoVehiculoService, TipoVehiculoService>();
            services.AddScoped<IValoracionRepository, ValoracionRepository>();
            services.AddScoped<IValoracionService, ValoracionService>();
 */

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

          

            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IVehiculoService, VehiculoService>(); 






            //Aquí agregar las otras entidades y agregados

            // Registrar JwtService como Singleton
            //services.AddSingleton<JwtService>();

            return services;
        }
    }
}

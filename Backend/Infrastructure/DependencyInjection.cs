//using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
//using Application.Services.Entidades;
//using Infrastructure.Repositorio.Entidades;
using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Application.Interfaces.Entidades.CiudadInterfaces;
//using Application.Interfaces.Entidades.DatosPagosInterfaces;
using Application.Interfaces.Entidades.DepartamentoInterfaces;
//using Application.Interfaces.Entidades.DetalleFacturasInterfaces;
using Application.Interfaces.Entidades.DireccionInterfaces;
/*using Application.Interfaces.Entidades.EmpleadosInterfaces;
using Application.Interfaces.Entidades.EmpresaInterfaces;
using Application.Interfaces.Entidades.EncabezadoFacturasInterfaces;
using Application.Interfaces.Entidades.EstadosReservaInterfaces;
using Application.Interfaces.Entidades.MarcasInterfaces;
using Application.Interfaces.Entidades.MetodosPagoInterfaces;
using Application.Interfaces.Entidades.ModelosInterfaces; */
using Application.Interfaces.Entidades.PaisInterfaces;
using Application.Interfaces.Entidades.PersonaInterfaces;
//using Application.Interfaces.Entidades.PropiedadesInterfaces;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
/*using Application.Interfaces.Entidades.ReseñasPropiedadInterfaces;
using Application.Interfaces.Entidades.ReseñasVehiculoInterfaces;
using Application.Interfaces.Entidades.ReservasInterfaces;
using Application.Interfaces.Entidades.ReservasVehiculoInterfaces; */
using Application.Interfaces.Entidades.RolInterfaces;
/*using Application.Interfaces.Entidades.SucursalesInterfaces;
using Application.Interfaces.Entidades.TelefonosInterfaces;
using Application.Interfaces.Entidades.TiposVehiculoInterfaces;
using Application.Interfaces.Entidades.UsuariosInterfaces;
using Application.Interfaces.Entidades.ValoracionesInterfaces;
using Application.Interfaces.Entidades.VehiculoInterfaces; */
// Repositories


using Application.Interfaces.Entidades.RolInterfaces;
using Application.Services.Entidades;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Entidades;
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
/*
            services.AddScoped<IDatosPagosRepository, DatosPagosRepository>();
            services.AddScoped<IDatosPagosService, DatosPagosService>();

           

            services.AddScoped<IDetalleFacturasRepository, DetalleFacturasRepository>();
            services.AddScoped<IDetalleFacturasService, DetalleFacturasService>();

          

            services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();
            services.AddScoped<IEmpleadosService, EmpleadosService>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IEncabezadoFacturasRepository, EncabezadoFacturasRepository>();
            services.AddScoped<IEncabezadoFacturasService, EncabezadoFacturasService>();

            services.AddScoped<IEstadosReservaRepository, EstadosReservaRepository>();
            services.AddScoped<IEstadosReservaService, EstadosReservaService>();

            services.AddScoped<IMarcasRepository, MarcasRepository>();
            services.AddScoped<IMarcasService, MarcasService>();

            services.AddScoped<IMetodosPagoRepository, MetodosPagoRepository>();
            services.AddScoped<IMetodosPagoService, MetodosPagoService>();

            services.AddScoped<IModelosRepository, ModelosRepository>();
            services.AddScoped<IModelosService, ModelosService>();



            services.AddScoped<IPropiedadesRepository, PropiedadesRepository>();
            services.AddScoped<IPropiedadesService, PropiedadesService>();

         

            services.AddScoped<IReseñasPropiedadRepository, ReseñasPropiedadRepository>();
            services.AddScoped<IReseñasPropiedadService, ReseñasPropiedadService>();

            services.AddScoped<IReseñasVehiculoRepository, ReseñasVehiculoRepository>();
            services.AddScoped<IReseñasVehiculoService, ReseñasVehiculoService>();

            services.AddScoped<IReservasRepository, ReservasRepository>();
            services.AddScoped<IReservasService, ReservasService>();

            services.AddScoped<IReservasVehiculoRepository, ReservasVehiculoRepository>();
            services.AddScoped<IReservasVehiculoService, ReservasVehiculoService>();


            services.AddScoped<ISucursalesRepository, SucursalesRepository>();
            services.AddScoped<ISucursalesService, SucursalesService>();

            services.AddScoped<ITelefonosRepository, TelefonosRepository>();
            services.AddScoped<ITelefonosService, TelefonosService>();

            services.AddScoped<ITiposVehiculoRepository, TiposVehiculoRepository>();
            services.AddScoped<ITiposVehiculoService, TiposVehiculoService>();

            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IUsuariosService, UsuariosService>();

            services.AddScoped<IValoracionesRepository, ValoracionesRepository>();
            services.AddScoped<IValoracionesService, ValoracionesService>();


            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IVehiculoService, VehiculoService>(); 
*/





            //Aquí agregar las otras entidades y agregados

            // Registrar JwtService como Singleton
            //services.AddSingleton<JwtService>();

            return services;
        }
    }
}

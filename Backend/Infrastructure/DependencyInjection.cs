//using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
//using Application.Services.Entidades;
//using Infrastructure.Repositorio.Entidades;
using Application.Interfaces;

using Application.Services;
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

            services.AddScoped<IAreasTrabajoRepository, AreasTrabajoRepository>();
            services.AddScoped<IAreasTrabajoService, AreasTrabajoService>();

            services.AddScoped<ICiudadesRepository, CiudadesRepository>();
            services.AddScoped<ICiudadesService, CiudadesService>();

            services.AddScoped<IDatosPagosRepository, DatosPagosRepository>();
            services.AddScoped<IDatosPagosService, DatosPagosService>();

            services.AddScoped<IDepartamentosRepository, DepartamentosRepository>();
            services.AddScoped<IDepartamentosService, DepartamentosService>();

            services.AddScoped<IDetalleFacturasRepository, DetalleFacturasRepository>();
            services.AddScoped<IDetalleFacturasService, DetalleFacturasService>();

            services.AddScoped<IDireccionesRepository, DireccionesRepository>();
            services.AddScoped<IDireccionesService, DireccionesService>();

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

            services.AddScoped<IPaisesRepository, PaisesRepository>();
            services.AddScoped<IPaisesService, PaisesService>();

            services.AddScoped<IPersonasRepository, PersonasRepository>();
            services.AddScoped<IPersonasService, PersonasService>();

            services.AddScoped<IPropiedadesRepository, PropiedadesRepository>();
            services.AddScoped<IPropiedadesService, PropiedadesService>();

            services.AddScoped<IPuestosTrabajoRepository, PuestosTrabajoRepository>();
            services.AddScoped<IPuestosTrabajoService, PuestosTrabajoService>();

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





            //Aquí agregar las otras entidades y agregados

            // Registrar JwtService como Singleton
            //services.AddSingleton<JwtService>();

            return services;
        }
    }
}

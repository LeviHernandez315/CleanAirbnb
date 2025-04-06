using Application.DTOs.Entidades.PropiedadDTOs;
using Application.Interfaces.Entidades.PropiedadInterfaces;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services.Entidades
{
    public class PropiedadService : IPropiedadService
    {
        private readonly IPropiedadRepository _propiedadRepository;

        public PropiedadService(IPropiedadRepository propiedadRepository)
        {
            _propiedadRepository = propiedadRepository;
        }

        public async Task<IEnumerable<PropiedadResponseDTO>> GetAllAsync()
        {
            var propiedades = await _propiedadRepository.GetAllAsync();
            return propiedades.Select(pr => new PropiedadResponseDTO
            {
                Id = pr.Id, 
                Nombre = pr.Nombre,
                Descripcion = pr.Descripcion,
                IdDireccion = pr.IdDireccion,
                Capacidad = pr.Capacidad,
                NumeroHabitaciones = pr.NumeroHabitaciones,
                NumeroCamas = pr.NumeroCamas,
                CapacidadParqueo = pr.CapacidadParqueo,
                PrecioPorNoche = pr.PrecioPorNoche,
                IdAnfitrion = pr.IdAnfitrion,
                IdEstadoReserva = pr.IdEstadoReserva,
                MediaValoracion = pr.MediaValoracion
            });
        }

        public async Task<PropiedadResponseDTO?> GetByIdAsync(int id)
        {
            var propiedad = await _propiedadRepository.GetByIdAsync(id);
            if (propiedad == null) return null;
            return new PropiedadResponseDTO
            {
                Id = propiedad.Id,
                Nombre = propiedad.Nombre,
                Descripcion = propiedad.Descripcion,
                IdDireccion = propiedad.IdDireccion,
                Capacidad = propiedad.Capacidad,
                NumeroHabitaciones = propiedad.NumeroHabitaciones,
                NumeroCamas = propiedad.NumeroCamas,
                CapacidadParqueo = propiedad.CapacidadParqueo,
                PrecioPorNoche = propiedad.PrecioPorNoche,
                IdAnfitrion = propiedad.IdAnfitrion,
                IdEstadoReserva = propiedad.IdEstadoReserva,
                MediaValoracion = propiedad.MediaValoracion
            };
        }

        public async Task<PropiedadResponseDTO> CreateAsync(PropiedadRequestDTO dto)
        {
            var propiedad = new Propiedad
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                IdDireccion = dto.IdDireccion,
                Capacidad = dto.Capacidad,
                NumeroHabitaciones = dto.NumeroHabitaciones,
                NumeroCamas = dto.NumeroCamas,
                CapacidadParqueo = dto.CapacidadParqueo,
                PrecioPorNoche = dto.PrecioPorNoche,
                IdAnfitrion = dto.IdAnfitrion,
                IdEstadoReserva = dto.IdEstadoReserva,
                MediaValoracion = dto.MediaValoracion
            };

            await _propiedadRepository.AddAsync(propiedad);

            return new PropiedadResponseDTO
            {
                Id = propiedad.Id,
                Nombre = propiedad.Nombre,
                Descripcion = propiedad.Descripcion,
                IdDireccion = propiedad.IdDireccion,
                Capacidad = propiedad.Capacidad,
                NumeroHabitaciones = propiedad.NumeroHabitaciones,
                NumeroCamas = propiedad.NumeroCamas,
                CapacidadParqueo = propiedad.CapacidadParqueo,
                PrecioPorNoche = propiedad.PrecioPorNoche,
                IdAnfitrion = propiedad.IdAnfitrion,
                IdEstadoReserva = propiedad.IdEstadoReserva,
                MediaValoracion = propiedad.MediaValoracion
            };
        }

        public async Task<bool> UpdateAsync(int id, PropiedadRequestDTO dto)
        {
            var propiedad = await _propiedadRepository.GetByIdAsync(id);
            if (propiedad == null) return false;

            propiedad.Nombre = dto.Nombre;
            propiedad.Descripcion = dto.Descripcion;
            propiedad.IdDireccion = dto.IdDireccion;
            propiedad.Capacidad = dto.Capacidad;
            propiedad.NumeroHabitaciones = dto.NumeroHabitaciones;
            propiedad.NumeroCamas = dto.NumeroCamas;
            propiedad.CapacidadParqueo = dto.CapacidadParqueo;
            propiedad.PrecioPorNoche = dto.PrecioPorNoche;
            propiedad.IdAnfitrion = dto.IdAnfitrion;
            propiedad.IdEstadoReserva = dto.IdEstadoReserva;
            propiedad.MediaValoracion = dto.MediaValoracion;

            return await _propiedadRepository.UpdateAsync(propiedad);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _propiedadRepository.DeleteAsync(id);
        }
    }
}
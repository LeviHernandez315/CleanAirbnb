using Application.DTOs.Entidades.VehiculoDTOs;
using Application.Interfaces.Entidades.VehiculoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<VehiculoResponseDTO>> GetAllAsync()
        {
            var vehiculos = await _vehiculoRepository.GetAllAsync();
            return vehiculos.Select(v => new VehiculoResponseDTO
            {
                Id = v.Id,
                IdModelo = v.IdModelo,
                IdDireccion = v.IdDireccion,
                Anio = v.Anio,
                IdTipoVehiculo = v.IdTipoVehiculo,
                PrecioDia = v.PrecioDia,
                IdEstadoReserva = v.IdEstadoReserva,
                ImagenUrl = v.ImagenUrl
            });
        }

        public async Task<VehiculoResponseDTO?> GetByIdAsync(int id)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);
            if (vehiculo == null) return null;
            return new VehiculoResponseDTO
            {
                Id = vehiculo.Id,
                IdModelo = vehiculo.IdModelo,
                IdDireccion = vehiculo.IdDireccion,
                Anio = vehiculo.Anio,
                IdTipoVehiculo = vehiculo.IdTipoVehiculo,
                PrecioDia = vehiculo.PrecioDia,
                IdEstadoReserva = vehiculo.IdEstadoReserva,
                ImagenUrl = vehiculo.ImagenUrl

            };
        }

        public async Task<VehiculoResponseDTO> CreateAsync(VehiculoRequestDTO dto)
        {
            var vehiculo = new Vehiculo
            {
                IdModelo = dto.IdModelo,
                IdDireccion = dto.IdDireccion,
                Anio = dto.Anio,
                IdTipoVehiculo = dto.IdTipoVehiculo,
                PrecioDia = dto.PrecioDia,
                IdEstadoReserva = dto.IdEstadoReserva,
                ImagenUrl = dto.ImagenUrl
            };

            await _vehiculoRepository.AddAsync(vehiculo);

            return new VehiculoResponseDTO
            {
                Id = vehiculo.Id,
                IdModelo = vehiculo.IdModelo,
                IdDireccion = vehiculo.IdDireccion,
                Anio = vehiculo.Anio,
                IdTipoVehiculo = vehiculo.IdTipoVehiculo,
                PrecioDia = vehiculo.PrecioDia,
                IdEstadoReserva = vehiculo.IdEstadoReserva,
                ImagenUrl = vehiculo.ImagenUrl
            };
        }

        public async Task<bool> UpdateAsync(int id, VehiculoRequestDTO dto)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);
            if (vehiculo == null) return false;

            vehiculo.IdModelo = dto.IdModelo;
            vehiculo.IdDireccion = dto.IdDireccion;
            vehiculo.Anio = dto.Anio;
            vehiculo.IdTipoVehiculo = dto.IdTipoVehiculo;
            vehiculo.PrecioDia = dto.PrecioDia;
            vehiculo.IdEstadoReserva = dto.IdEstadoReserva;
            vehiculo.ImagenUrl = dto.ImagenUrl;

            return await _vehiculoRepository.UpdateAsync(vehiculo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _vehiculoRepository.DeleteAsync(id);
        }
    }
}
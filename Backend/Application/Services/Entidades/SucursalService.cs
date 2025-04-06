using Application.DTOs.Entidades.SucursalDTOs;
using Application.Interfaces.Entidades.SucursalInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public async Task<IEnumerable<SucursalResponseDTO>> GetAllAsync()
        {
            var items = await _sucursalRepository.GetAllAsync();
            return items.Select(e => new SucursalResponseDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                IdDireccion = e.IdDireccion,
                Telefono = e.Telefono,
                CodigoSAR = e.CodigoSAR,
                IdEmpresa = e.IdEmpresa
            });
        }

        public async Task<SucursalResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _sucursalRepository.GetByIdAsync(id);
            if (item == null) return null;

            return new SucursalResponseDTO
            {
                Id = item.Id,
                Nombre = item.Nombre,
                IdDireccion = item.IdDireccion,
                Telefono = item.Telefono,
                CodigoSAR = item.CodigoSAR,
                IdEmpresa = item.IdEmpresa
            };
        }

        public async Task<SucursalResponseDTO> CreateAsync(SucursalRequestDTO dto)
        {
            var item = new Sucursal
            {
                Nombre = dto.Nombre,
                IdDireccion = dto.IdDireccion,
                Telefono = dto.Telefono,
                CodigoSAR = dto.CodigoSAR,
                IdEmpresa = dto.IdEmpresa
            };

            await _sucursalRepository.AddAsync(item);

            return new SucursalResponseDTO
            {
                Id = item.Id,
                Nombre = item.Nombre,
                IdDireccion = item.IdDireccion,
                Telefono = item.Telefono,
                CodigoSAR = item.CodigoSAR,
                IdEmpresa = item.IdEmpresa
            };
        }

        public async Task<bool> UpdateAsync(int id, SucursalRequestDTO dto)
        {
            var item = await _sucursalRepository.GetByIdAsync(id);
            if (item == null) return false;

            item.Nombre = dto.Nombre;
            item.IdDireccion = dto.IdDireccion;
            item.Telefono = dto.Telefono;
            item.CodigoSAR = dto.CodigoSAR;
            item.IdEmpresa = dto.IdEmpresa;

            return await _sucursalRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _sucursalRepository.DeleteAsync(id);
        }
    }
}
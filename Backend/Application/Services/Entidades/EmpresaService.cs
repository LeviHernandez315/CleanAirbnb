using Application.DTOs.Entidades.EmpresaDTOs;
using Application.Interfaces.Entidades.EmpresaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<EmpresaResponseDTO>> GetAllAsync()
        {
            var items = await _empresaRepository.GetAllAsync();
            return items.Select(e => new EmpresaResponseDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Rtn = e.Rtn,
                Correo = e.Correo,
                CasaMatriz = e.CasaMatriz,
                Telefono = e.Telefono
            });
        }

        public async Task<EmpresaResponseDTO?> GetByIdAsync(int id)
        {
            var item = await _empresaRepository.GetByIdAsync(id);
            if (item == null) return null;

            return new EmpresaResponseDTO
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Rtn = item.Rtn,
                Correo = item.Correo,
                CasaMatriz = item.CasaMatriz,
                Telefono = item.Telefono
            };
        }

        public async Task<EmpresaResponseDTO> CreateAsync(EmpresaRequestDTO dto)
        {
            var item = new Empresa
            {
                Nombre = dto.Nombre,
                Rtn = dto.Rtn,
                Correo = dto.Correo,
                CasaMatriz = dto.CasaMatriz,
                Telefono = dto.Telefono
            };

            await _empresaRepository.AddAsync(item);

            return new EmpresaResponseDTO
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Rtn = item.Rtn,
                Correo = item.Correo,
                CasaMatriz = item.CasaMatriz,
                Telefono = item.Telefono
            };
        }

        public async Task<bool> UpdateAsync(int id, EmpresaRequestDTO dto)
        {
            var item = await _empresaRepository.GetByIdAsync(id);
            if (item == null) return false;

            item.Nombre = dto.Nombre;
            item.Rtn = dto.Rtn;
            item.Correo = dto.Correo;
            item.CasaMatriz = dto.CasaMatriz;
            item.Telefono = dto.Telefono;

            var updated = await _empresaRepository.UpdateAsync(item);
            return updated != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _empresaRepository.DeleteAsync(id);
        }
    }
}
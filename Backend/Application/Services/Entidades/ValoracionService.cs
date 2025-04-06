
using Application.DTOs.Entidades.ValoracionDTOs;
using Application.Interfaces.Entidades.ValoracionInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class ValoracionService: IValoracionService
    {
        private readonly IValoracionRepository _valoracionRepository;

        public ValoracionService(IValoracionRepository valoracionRepository)
        {
            _valoracionRepository = valoracionRepository;
        }

        public async Task<IEnumerable<ValoracionResponseDTO>> GetAllAsync()
        {
            var valoraciones = await _valoracionRepository.GetAllAsync();

            return valoraciones.Select(v => new ValoracionResponseDTO
            {
                Id = v.Id,
                Descripcion = v.Descripcion,
                Valor = v.Valor
            });
        }

        public async Task<ValoracionResponseDTO> GetByIdAsync(int id)
        {
            var valoracion = await _valoracionRepository.GetByIdAsync(id);

            if (valoracion == null)
                throw new Exception("Valoración no encontrada");

            return new ValoracionResponseDTO
            {
                Id = valoracion.Id,
                Descripcion = valoracion.Descripcion,
                Valor = valoracion.Valor
            };
        }

        public async Task<ValoracionResponseDTO> CreateAsync(ValoracionRequestDTO dto)
        {
            var valoracion = new Valoracion
            {
                Descripcion = dto.Descripcion,
                Valor = dto.Valor
            };

            var createdValoracion = await _valoracionRepository.CreateAsync(valoracion);

            return new ValoracionResponseDTO
            {
                Id = createdValoracion.Id,
                Descripcion = createdValoracion.Descripcion,
                Valor = createdValoracion.Valor
            };
        }

        public async Task<bool> UpdateAsync(int id, ValoracionRequestDTO dto)
        {
            var valoracion = await _valoracionRepository.GetByIdAsync(id);

            if (valoracion == null)
                return false;

            valoracion.Descripcion = dto.Descripcion;
            valoracion.Valor = dto.Valor;

            return await _valoracionRepository.UpdateAsync(valoracion);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _valoracionRepository.DeleteAsync(id);
        }
    }
}

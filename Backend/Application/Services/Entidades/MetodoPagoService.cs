
using Application.DTOs.Entidades.MetodoPagoDTOs;
using Application.Interfaces.Entidades.MetodoPagoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class MetodoPagoService: IMetodoPagoService
    {
        private readonly IMetodoPagoRepository _metodoPagoRepository;

        
        public MetodoPagoService(IMetodoPagoRepository metodoPagoRepository)
        {
            _metodoPagoRepository = metodoPagoRepository;
        }


        public async Task<IEnumerable<MetodoPagoResponseDTO>> GetAllAsync()
        {
            var lista = await _metodoPagoRepository.GetAllAsync();

            return lista.Select(m => new MetodoPagoResponseDTO
            {
                Id = m.Id,
                Descripcion = m.Descripcion
            });
        }

      
        public async Task<MetodoPagoResponseDTO> GetByIdAsync(int id)
        {
            var metodo = await _metodoPagoRepository.GetByIdAsync(id);

            if (metodo == null)
                throw new Exception("Método de pago no encontrado");

            return new MetodoPagoResponseDTO
            {
                Id = metodo.Id,
                Descripcion = metodo.Descripcion
            };
        }

      
        public async Task<MetodoPagoResponseDTO> CreateAsync(MetodoPagoRequestDTO dto)
        {
            var nuevoMetodo = new MetodoPago
            {
                Descripcion = dto.Descripcion
            };

            var metodoPago = await _metodoPagoRepository.CreateAsync(nuevoMetodo);

            return new MetodoPagoResponseDTO
            {
                Id = metodoPago.Id,
                Descripcion = metodoPago.Descripcion
            };
        }

       
        public async Task<bool> UpdateAsync(int id, MetodoPagoRequestDTO dto)
        {
            var metodoPago = await _metodoPagoRepository.GetByIdAsync(id);

            if (metodoPago == null)
                return false;

            metodoPago.Descripcion = dto.Descripcion;

            return await _metodoPagoRepository.UpdateAsync(metodoPago);
        }

      
        public async Task<bool> DeleteAsync(int id)
        {
            return await _metodoPagoRepository.DeleteAsync(id);
        }

    }
}

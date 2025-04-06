using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.MetodoPagoDTOs;
using Application.Interfaces.Entidades.MetodoPagoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class MetodoPagoService: IMetodoPagoService
    {
        private readonly IMetodoPagoRepository _repository;

        // Constructor que recibe el repositorio por inyección de dependencias
        public MetodoPagoService(IMetodoPagoRepository repository)
        {
            _repository = repository;
        }

        // Obtener todos los métodos de pago existentes
        public async Task<IEnumerable<MetodoPagoResponseDTO>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            // Convertimos las entidades del dominio en DTOs de respuesta
            return lista.Select(m => new MetodoPagoResponseDTO
            {
                Id = m.Id,
                Descripcion = m.Descripcion
            });
        }

        // Obtener un método de pago por su ID
        public async Task<MetodoPagoResponseDTO> GetByIdAsync(int id)
        {
            var metodo = await _repository.GetByIdAsync(id);

            if (metodo == null)
                throw new Exception("Método de pago no encontrado");

            return new MetodoPagoResponseDTO
            {
                Id = metodo.Id,
                Descripcion = metodo.Descripcion
            };
        }

        // Crear un nuevo método de pago
        public async Task<MetodoPagoResponseDTO> CreateAsync(MetodoPagoRequestDTO dto)
        {
            var nuevoMetodo = new MetodoPago
            {
                Descripcion = dto.Descripcion
            };

            var metodoPago = await _repository.CreateAsync(nuevoMetodo);

            return new MetodoPagoResponseDTO
            {
                Id = metodoPago.Id,
                Descripcion = metodoPago.Descripcion
            };
        }

        // Actualizar un método de pago 
        public async Task<bool> UpdateAsync(int id, MetodoPagoRequestDTO dto)
        {
            var metodoPago = await _repository.GetByIdAsync(id);

            if (metodoPago == null)
                return false;

            metodoPago.Descripcion = dto.Descripcion;

            return await _repository.UpdateAsync(metodoPago);
        }

        // Eliminar un método de pago por su ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.TipoVehiculoDTOs;
using Application.Interfaces.Entidades.TipoVehiculoInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
    {
        public class TipoVehiculoService : ITipoVehiculoService
        {
            private readonly ITipoVehiculoRepository _tipoVehiculoRepository;

            public TipoVehiculoService(ITipoVehiculoRepository tipoVehiculoRepository)
            {
                _tipoVehiculoRepository = tipoVehiculoRepository;
            }

            public async Task<IEnumerable<TipoVehiculoResponseDTO>> GetAllAsync()
            {
                var tipos = await _tipoVehiculoRepository.GetAllAsync();

                return tipos.Select(t => new TipoVehiculoResponseDTO
                {
                    Id = t.Id,
                    Descripcion = t.Descripcion
                });
            }

            public async Task<TipoVehiculoResponseDTO?> GetByIdAsync(int id)
            {
                var tipo = await _tipoVehiculoRepository.GetByIdAsync(id);

                if (tipo == null)
                    return null;

                return new TipoVehiculoResponseDTO
                {
                    Id = tipo.Id,
                    Descripcion = tipo.Descripcion
                };
            }

            public async Task<TipoVehiculoResponseDTO> CreateAsync(TipoVehiculoRequestDTO dto)
            {
                var tipo = new TipoVehiculo
                {
                    Descripcion = dto.Descripcion
                };

                await _tipoVehiculoRepository.AddAsync(tipo);

                return new TipoVehiculoResponseDTO
                {
                    Id = tipo.Id,
                    Descripcion = tipo.Descripcion
                };
            }

            public async Task<bool> UpdateAsync(int id, TipoVehiculoRequestDTO dto)
            {
                var tipoVehiculo = await _tipoVehiculoRepository.GetByIdAsync(id);

                if (tipoVehiculo == null)
                    return false;

                tipoVehiculo.Descripcion = dto.Descripcion;

                await _tipoVehiculoRepository.UpdateAsync(tipoVehiculo);
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var tipo = await _tipoVehiculoRepository.GetByIdAsync(id);

                if (tipo == null)
                    return false;

                await _tipoVehiculoRepository.DeleteAsync(id);
                return true;
            }
        }
    }

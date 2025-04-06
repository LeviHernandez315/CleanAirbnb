using Application.DTOs.Entidades.EmpleadoDTOs;
using Application.Interfaces.Entidades.EmpleadoInterfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services.Entidades
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<EmpleadoResponseDTO>> GetAllAsync()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return empleados.Select(e => new EmpleadoResponseDTO
            {
                Id = e.Id,
                Email = e.Email,
                Dni = e.Dni,
                RolId = e.RolId,
                PuestoId = e.PuestoId,
                Salario = e.Salario,
                DireccionId = e.DireccionId
            });
        }

        public async Task<EmpleadoResponseDTO?> GetByIdAsync(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return null;
            return new EmpleadoResponseDTO
            {
                Id = empleado.Id,
                Email = empleado.Email,
                Dni = empleado.Dni,
                RolId = empleado.RolId,
                PuestoId = empleado.PuestoId,
                Salario = empleado.Salario,
                DireccionId = empleado.DireccionId
            };
        }

        public async Task<EmpleadoResponseDTO> CreateAsync(EmpleadoRequestDTO dto)
        {
            var empleado = new Empleado
            {
                Email = dto.Email,
                Password = dto.Password,
                Dni = dto.Dni,
                RolId = dto.RolId,
                PuestoId = dto.PuestoId,
                Salario = dto.Salario,
                DireccionId = dto.DireccionId
            };

            await _empleadoRepository.AddAsync(empleado);

            return new EmpleadoResponseDTO
            {
                Id = empleado.Id,
                Email = empleado.Email,
                Dni = empleado.Dni,
            };
        }

        public async Task<bool> UpdateAsync(int id, EmpleadoRequestDTO dto)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return false;

            empleado.Email = dto.Email;
            empleado.Password = dto.Password;
            empleado.Dni = dto.Dni;
            empleado.RolId = dto.RolId;
            empleado.PuestoId = dto.PuestoId;
            empleado.Salario = dto.Salario;
            empleado.DireccionId = dto.DireccionId;

            return await _empleadoRepository.UpdateAsync(empleado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _empleadoRepository.DeleteAsync(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Entidades.PersonaDTOs;
using Application.Interfaces.Entidades.PersonaInterfaces;
using Domain.Entities;

namespace Application.Services.Entidades
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<PersonaResponseDTO>> GetAllAsync()
        {
            var personas = await _personaRepository.GetAllAsync();

            return personas.Select(p => new PersonaResponseDTO
            {
                DNI = p.DNI,
                RTN = p.RTN,
                PrimerNombre = p.PrimerNombre,
                SegundoNombre = p.SegundoNombre,
                PrimerApellido = p.PrimerApellido,
                SegundoApellido = p.SegundoApellido,
                Edad = p.Edad,
                FechaNacimiento = p.FechaNacimiento
            });
        }

        public async Task<PersonaResponseDTO?> GetByIdAsync(string dni)
        {
            var persona = await _personaRepository.GetByIdAsync(dni);

            if (persona == null) return null;

            return new PersonaResponseDTO
            {
                DNI = persona.DNI,
                RTN = persona.RTN,
                PrimerNombre = persona.PrimerNombre,
                SegundoNombre = persona.SegundoNombre,
                PrimerApellido = persona.PrimerApellido,
                SegundoApellido = persona.SegundoApellido,
                Edad = persona.Edad,
                FechaNacimiento = persona.FechaNacimiento
            };
        }

        public async Task<PersonaResponseDTO> CreateAsync(PersonaRequestDTO dto)
        {
            var persona = new Persona
            {
                DNI = dto.DNI,
                RTN = dto.RTN,
                PrimerNombre = dto.PrimerNombre,
                SegundoNombre = dto.SegundoNombre,
                PrimerApellido = dto.PrimerApellido,
                SegundoApellido = dto.SegundoApellido,
                Edad = dto.Edad,
                FechaNacimiento = dto.FechaNacimiento
            };

            await _personaRepository.AddAsync(persona);

            return new PersonaResponseDTO
            {
                DNI = persona.DNI,
                RTN = persona.RTN,
                PrimerNombre = persona.PrimerNombre,
                SegundoNombre = persona.SegundoNombre,
                PrimerApellido = persona.PrimerApellido,
                SegundoApellido = persona.SegundoApellido,
                Edad = persona.Edad,
                FechaNacimiento = persona.FechaNacimiento
            };
        }

        public async Task<bool> UpdateAsync(string dni, PersonaRequestDTO dto)
        {
            var persona = await _personaRepository.GetByIdAsync(dni);
            if (persona == null) return false;

            persona.RTN = dto.RTN;
            persona.PrimerNombre = dto.PrimerNombre;
            persona.SegundoNombre = dto.SegundoNombre;
            persona.PrimerApellido = dto.PrimerApellido;
            persona.SegundoApellido = dto.SegundoApellido;
            persona.Edad = dto.Edad;
            persona.FechaNacimiento = dto.FechaNacimiento;

            return await _personaRepository.UpdateAsync(persona);
        }

        public async Task<bool> DeleteAsync(string dni)
        {
            return await _personaRepository.DeleteAsync(dni);
        }
    }
}

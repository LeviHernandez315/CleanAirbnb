using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.PersonaInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly BackendDBContext _context;

        public PersonaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(string dni)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.DNI == dni);
        }

        public async Task AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Persona persona)
        {
            var existente = await _context.Personas.FindAsync(persona.DNI);
            if (existente == null) return false;

            existente.RTN = persona.RTN;
            existente.PrimerNombre = persona.PrimerNombre;
            existente.SegundoNombre = persona.SegundoNombre;
            existente.PrimerApellido = persona.PrimerApellido;
            existente.SegundoApellido = persona.SegundoApellido;
            existente.Edad = persona.Edad;
            existente.FechaNacimiento = persona.FechaNacimiento;

            _context.Personas.Update(existente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string dni)
        {
            var persona = await _context.Personas.FindAsync(dni);
            if (persona == null) return false;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

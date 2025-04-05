using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.DireccionInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly BackendDBContext _context;

        public DireccionRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Direccion>> GetAllAsync()
        {
            return await _context.Direcciones.ToListAsync(); 
        }

        public async Task<Direccion?> GetByIdAsync(int id)
        {
            return await _context.Direcciones.FirstOrDefaultAsync(d => d.Id == id); // sin Include
        }

        public async Task AddAsync(Direccion direccion)
        {
            await _context.Direcciones.AddAsync(direccion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Direccion direccion)
        {
            var existente = await _context.Direcciones.FindAsync(direccion.Id);
            if (existente == null)
                return false;

            existente.NumCasa = direccion.NumCasa;
            existente.Calle = direccion.Calle;
            existente.Colonia = direccion.Colonia;
            existente.IdCiudad = direccion.IdCiudad;

            _context.Direcciones.Update(existente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion == null)
                return false;

            _context.Direcciones.Remove(direccion);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

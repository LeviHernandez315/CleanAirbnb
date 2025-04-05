using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class PuestoTrabajoRepository : IPuestoTrabajoRepository
    {
        private readonly BackendDBContext _context;

        public PuestoTrabajoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PuestoTrabajo>> GetAllAsync()
        {
            return await _context.PuestosTrabajo.ToListAsync();
        }

        public async Task<PuestoTrabajo?> GetByIdAsync(int id)
        {
            return await _context.PuestosTrabajo.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(PuestoTrabajo puesto)
        {
            await _context.PuestosTrabajo.AddAsync(puesto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(PuestoTrabajo puesto)
        {
            var existente = await _context.PuestosTrabajo.FindAsync(puesto.Id);
            if (existente == null) return false;

            existente.Descripcion = puesto.Descripcion;
            existente.IdArea = puesto.IdArea;

            _context.PuestosTrabajo.Update(existente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var puesto = await _context.PuestosTrabajo.FindAsync(id);
            if (puesto == null) return false;

            _context.PuestosTrabajo.Remove(puesto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

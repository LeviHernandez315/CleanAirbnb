
using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Entidades
{
    public class AreaTrabajoRepository : IAreaTrabajoRepository
    {

        private readonly BackendDBContext _context;

        public AreaTrabajoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AreaTrabajo areaTrabajo)
        {
            _context.AreasTrabajo.Add(areaTrabajo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var areaTrabajo = await _context.AreasTrabajo.FindAsync(id);
            if (areaTrabajo is null) return false;

            _context.AreasTrabajo.Remove(areaTrabajo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<AreaTrabajo>> GetAllAsync()
        {
            return await _context.AreasTrabajo.ToListAsync();
        }

        public async Task<AreaTrabajo?> GetByIdAsync(int id)
        {
            return await _context.AreasTrabajo.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(AreaTrabajo areaTrabajo)
        {
            _context.AreasTrabajo.Update(areaTrabajo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

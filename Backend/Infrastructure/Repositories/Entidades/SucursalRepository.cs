using Application.Interfaces.Entidades.SucursalInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly BackendDBContext _context;

        public SucursalRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            return await _context.Set<Sucursal>().ToListAsync();
        }

        public async Task<Sucursal?> GetByIdAsync(int id)
        {
            return await _context.Set<Sucursal>().FindAsync(id);
        }

        public async Task AddAsync(Sucursal entity)
        {
            await _context.Set<Sucursal>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Sucursal entity)
        {
            var existing = await _context.Set<Sucursal>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Sucursal>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Sucursal>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
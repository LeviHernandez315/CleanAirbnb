using Application.Interfaces.Entidades.DatosPagoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class DatosPagoRepository : IDatosPagoRepository
    {
        private readonly BackendDBContext _context;

        public DatosPagoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DatosPago>> GetAllAsync()
        {
            return await _context.Set<DatosPago>().ToListAsync();
        }

        public async Task<DatosPago?> GetByIdAsync(int id)
        {
            return await _context.Set<DatosPago>().FindAsync(id);
        }

        public async Task AddAsync(DatosPago entity)
        {
            await _context.Set<DatosPago>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(DatosPago entity)
        {
            var existing = await _context.Set<DatosPago>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<DatosPago>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<DatosPago>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
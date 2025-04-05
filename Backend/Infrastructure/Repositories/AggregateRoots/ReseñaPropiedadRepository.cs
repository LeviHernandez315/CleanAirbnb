using Application.Interfaces.AggregateRoots.ReseñaPropiedadInterfaces;

using Microsoft.EntityFrameworkCore;
using Domain.AggregateRoots;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories.AggregateRoots
{ 
    public class ReseñaPropiedadRepository : IReseñaPropiedadRepository
    {
        private readonly BackendDBContext _context;

        public ReseñaPropiedadRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReseñaPropiedad>> GetAllAsync()
        {
            return await _context.Set<ReseñaPropiedad>().ToListAsync();
        }

        public async Task<ReseñaPropiedad?> GetByIdAsync(int id)
        {
            return await _context.Set<ReseñaPropiedad>().FindAsync(id);
        }

        public async Task AddAsync(ReseñaPropiedad entity)
        {
            await _context.Set<ReseñaPropiedad>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ReseñaPropiedad entity)
        {
            var existing = await _context.Set<ReseñaPropiedad>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<ReseñaPropiedad>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<ReseñaPropiedad>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
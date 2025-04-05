using Application.Interfaces.AggregateRoots.ReseñaVehiculoInterfaces;
using Microsoft.EntityFrameworkCore;
using Domain.AggregateRoots;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories.AggregateRoots
{
    public class ReseñaVehiculoRepository : IReseñaVehiculoRepository
    {
        private readonly BackendDBContext _context;

        public ReseñaVehiculoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReseñaVehiculo>> GetAllAsync()
        {
            return await _context.Set<ReseñaVehiculo>().ToListAsync();
        }

        public async Task<ReseñaVehiculo?> GetByIdAsync(int id)
        {
            return await _context.Set<ReseñaVehiculo>().FindAsync(id);
        }

        public async Task AddAsync(ReseñaVehiculo entity)
        {
            await _context.Set<ReseñaVehiculo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ReseñaVehiculo entity)
        {
            var existing = await _context.Set<ReseñaVehiculo>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<ReseñaVehiculo>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<ReseñaVehiculo>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
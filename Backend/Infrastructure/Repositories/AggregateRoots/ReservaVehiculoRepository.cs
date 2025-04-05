using Application.Interfaces.AggregateRoots.ReservaVehiculoInterfaces;
using Microsoft.EntityFrameworkCore;
using Domain.AggregateRoots;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories.AggregateRoots
{
    public class ReservaVehiculoRepository : IReservaVehiculoRepository
    {
        private readonly BackendDBContext _context;

        public ReservaVehiculoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservaVehiculo>> GetAllAsync()
        {
            return await _context.Set<ReservaVehiculo>().ToListAsync();
        }

        public async Task<ReservaVehiculo?> GetByIdAsync(int id)
        {
            return await _context.Set<ReservaVehiculo>().FindAsync(id);
        }

        public async Task AddAsync(ReservaVehiculo entity)
        {
            await _context.Set<ReservaVehiculo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ReservaVehiculo entity)
        {
            var existing = await _context.Set<ReservaVehiculo>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<ReservaVehiculo>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<ReservaVehiculo>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
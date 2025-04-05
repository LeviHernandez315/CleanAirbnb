using Application.Interfaces.AggregateRoots.ReservaInterfaces;
using Microsoft.EntityFrameworkCore;
using Domain.AggregateRoots;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories.AggregateRoots
{ 
    public class ReservaRepository : IReservaRepository
    {
        private readonly BackendDBContext _context;

        public ReservaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Set<Reserva>().ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Set<Reserva>().FindAsync(id);
        }

        public async Task AddAsync(Reserva entity)
        {
            await _context.Set<Reserva>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Reserva entity)
        {
            var existing = await _context.Set<Reserva>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Reserva>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Reserva>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
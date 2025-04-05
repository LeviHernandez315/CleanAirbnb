using Application.Interfaces.Entidades.EstadoReservaInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class EstadoReservaRepository : IEstadoReservaRepository
    {
        private readonly BackendDBContext _context;

        public EstadoReservaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoReserva>> GetAllAsync()
        {
            return await _context.Set<EstadoReserva>().ToListAsync();
        }

        public async Task<EstadoReserva?> GetByIdAsync(int id)
        {
            return await _context.Set<EstadoReserva>().FindAsync(id);
        }

        public async Task AddAsync(EstadoReserva entity)
        {
            await _context.Set<EstadoReserva>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(EstadoReserva entity)
        {
            var existing = await _context.Set<EstadoReserva>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<EstadoReserva>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<EstadoReserva>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
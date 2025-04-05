using Application.Interfaces.Entidades.VehiculoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly BackendDBContext _context;

        public VehiculoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Set<Vehiculo>().ToListAsync();
        }

        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _context.Set<Vehiculo>().FindAsync(id);
        }

        public async Task AddAsync(Vehiculo entity)
        {
            await _context.Set<Vehiculo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Vehiculo entity)
        {
            var existing = await _context.Set<Vehiculo>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Vehiculo>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Vehiculo>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
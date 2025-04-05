using Application.Interfaces.Entidades.PropiedadInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private readonly BackendDBContext _context;

        public PropiedadRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Propiedad>> GetAllAsync()
        {
            return await _context.Set<Propiedad>().ToListAsync();
        }

        public async Task<Propiedad?> GetByIdAsync(int id)
        {
            return await _context.Set<Propiedad>().FindAsync(id);
        }

        public async Task AddAsync(Propiedad entity)
        {
            await _context.Set<Propiedad>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Propiedad entity)
        {
            var existing = await _context.Set<Propiedad>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Propiedad>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Propiedad>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
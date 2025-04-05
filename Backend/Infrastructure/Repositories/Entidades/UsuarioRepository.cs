using Application.Interfaces.Entidades.UsuarioInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BackendDBContext _context;

        public UsuarioRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Set<Usuario>().ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Set<Usuario>().FindAsync(id);
        }

        public async Task AddAsync(Usuario entity)
        {
            await _context.Set<Usuario>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            var existing = await _context.Set<Usuario>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Usuario>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Usuario>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
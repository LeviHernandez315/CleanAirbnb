
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Entidades.MarcaInterfaces;

namespace Infrastructure.Repositories.Entidades
{
    public class MarcaRepository: IMarcaRepository
    {
        private readonly BackendDBContext _context;

        public MarcaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetAllAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca?> GetByIdAsync(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task AddAsync(Marca marca)
        {
            await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Marca marca)
        {
            var existing = await _context.Marcas.FindAsync(marca.Id);
            if (existing == null)
                return false;

            existing.Descripcion = marca.Descripcion;
            _context.Marcas.Update(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
                return false;

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

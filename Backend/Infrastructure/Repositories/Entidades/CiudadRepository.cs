using Application.Interfaces.Entidades.CiudadInterfaces;
using Dominio.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class CiudadRepository : ICiudadRepository
    {

        private readonly BackendDBContext _context;

        public CiudadRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ciudad ciudad)
        {
            _context.Ciudades.Add(ciudad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad is null) return false;

            _context.Ciudades.Remove(ciudad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades.ToListAsync();
        }

        public async Task<Ciudad?> GetByIdAsync(int id)
        {
            return await _context.Ciudades.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Ciudad ciudad)
        {
            _context.Ciudades.Update(ciudad);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

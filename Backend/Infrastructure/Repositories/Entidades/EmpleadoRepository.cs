using Application.Interfaces.Entidades.EmpleadoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly BackendDBContext _context;

        public EmpleadoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Set<Empleado>().ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Set<Empleado>().FindAsync(id);
        }

        public async Task AddAsync(Empleado entity)
        {
            await _context.Set<Empleado>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Empleado entity)
        {
            var existing = await _context.Set<Empleado>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Empleado>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Empleado>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
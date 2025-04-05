using Application.Interfaces.Entidades.EmpresaInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly BackendDBContext _context;

        public EmpresaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _context.Set<Empresa>().ToListAsync();
        }

        public async Task<Empresa?> GetByIdAsync(int id)
        {
            return await _context.Set<Empresa>().FindAsync(id);
        }

        public async Task AddAsync(Empresa entity)
        {
            await _context.Set<Empresa>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Empresa entity)
        {
            var existing = await _context.Set<Empresa>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<Empresa>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<Empresa>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
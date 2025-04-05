
using Application.Interfaces.AggregateRoots.EncabezadoFacturaInterfaces;
using Microsoft.EntityFrameworkCore;
using Domain.AggregateRoots;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories.AggregateRoots
{
    public class EncabezadoFacturaRepository : IEncabezadoFacturaRepository
    {
        private readonly BackendDBContext _context;

        public EncabezadoFacturaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EncabezadoFactura>> GetAllAsync()
        {
            return await _context.Set<EncabezadoFactura>().ToListAsync();
        }

        public async Task<EncabezadoFactura?> GetByIdAsync(int id)
        {
            return await _context.Set<EncabezadoFactura>().FindAsync(id);
        }

        public async Task AddAsync(EncabezadoFactura entity)
        {
            await _context.Set<EncabezadoFactura>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(EncabezadoFactura entity)
        {
            var existing = await _context.Set<EncabezadoFactura>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<EncabezadoFactura>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<EncabezadoFactura>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
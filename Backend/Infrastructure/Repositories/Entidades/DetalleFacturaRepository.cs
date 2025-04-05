using Application.Interfaces.Entidades.DetalleFacturaInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly BackendDBContext _context;

        public DetalleFacturaRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleFactura>> GetAllAsync()
        {
            return await _context.Set<DetalleFactura>().ToListAsync();
        }

        public async Task<DetalleFactura?> GetByIdAsync(int id)
        {
            return await _context.Set<DetalleFactura>().FindAsync(id);
        }

        public async Task AddAsync(DetalleFactura entity)
        {
            await _context.Set<DetalleFactura>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(DetalleFactura entity)
        {
            var existing = await _context.Set<DetalleFactura>().FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<DetalleFactura>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<DetalleFactura>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
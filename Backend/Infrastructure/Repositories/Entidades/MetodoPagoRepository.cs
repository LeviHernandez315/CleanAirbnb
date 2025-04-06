using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.MetodoPagoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class MetodoPagoRepository:IMetodoPagoRepository
    {
        private readonly BackendDBContext _context;

        public MetodoPagoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetodoPago>> GetAllAsync()
        {
            return await _context.MetodosPago.ToListAsync();
        }

        public async Task<MetodoPago?> GetByIdAsync(int id)
        {
            return await _context.MetodosPago.FindAsync(id);
        }

        public async Task<MetodoPago> CreateAsync(MetodoPago metodoPago)
        {
            _context.MetodosPago.Add(metodoPago);
            await _context.SaveChangesAsync();
            return metodoPago;
        }

        public async Task<bool> UpdateAsync(MetodoPago metodoPago)
        {
            _context.MetodosPago.Update(metodoPago);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var metodoPago = await _context.MetodosPago.FindAsync(id);
            if (metodoPago == null)
                return false;

            _context.MetodosPago.Remove(metodoPago);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}

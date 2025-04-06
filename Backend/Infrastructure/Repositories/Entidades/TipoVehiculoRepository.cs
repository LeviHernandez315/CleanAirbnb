using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.TipoVehiculoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class TipoVehiculoRepository : ITipoVehiculoRepository
    {
        private readonly BackendDBContext _context;

        public TipoVehiculoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoVehiculo>> GetAllAsync()
        {
            return await _context.TiposVehiculo.ToListAsync();
        }

        public async Task<TipoVehiculo?> GetByIdAsync(int id)
        {
            return await _context.TiposVehiculo.FindAsync(id);
        }

        public async Task AddAsync(TipoVehiculo tipoVehiculo)
        {
            _context.TiposVehiculo.Add(tipoVehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoVehiculo tipoVehiculo)
        {
            _context.TiposVehiculo.Update(tipoVehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipoVehiculo = await _context.TiposVehiculo.FindAsync(id);
            if (tipoVehiculo != null)
            {
                _context.TiposVehiculo.Remove(tipoVehiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}

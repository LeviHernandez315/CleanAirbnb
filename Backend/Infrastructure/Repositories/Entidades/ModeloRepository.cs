using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.ModeloInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly BackendDBContext _context;

        public ModeloRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modelo>> GetAllAsync()
        {
            return await _context.Modelos.ToListAsync();
        }

        public async Task<Modelo?> GetByIdAsync(int id)
        {
            return await _context.Modelos.FindAsync(id);
        }

        public async Task AddAsync(Modelo modelo)
        {
            await _context.Modelos.AddAsync(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Modelo modelo)
        {
            _context.Modelos.Update(modelo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo is null) return false;

            _context.Modelos.Remove(modelo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

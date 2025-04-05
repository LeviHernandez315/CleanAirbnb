using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.PaisInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class PaisRepository : IPaisRepository
    {

        private readonly BackendDBContext _context;

        public PaisRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pais pais)
        {
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais is null) return false;

            _context.Paises.Remove(pais);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises.ToListAsync();
        }

        public async Task<Pais?> GetByIdAsync(int id)
        {
            return await _context.Paises.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Pais pais)
        {
            _context.Paises.Update(pais);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

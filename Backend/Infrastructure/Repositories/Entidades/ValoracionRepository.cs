using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.ValoracionInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class ValoracionRepository : IValoracionRepository
    {
        private readonly BackendDBContext _context;

        public ValoracionRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Valoracion>> GetAllAsync()
        {
            return await _context.Valoraciones.ToListAsync();
        }

        public async Task<Valoracion?> GetByIdAsync(int id)
        {
            return await _context.Valoraciones.FindAsync(id);
        }

        public async Task<Valoracion> CreateAsync(Valoracion valoracion)
        {
            _context.Valoraciones.Add(valoracion);
            await _context.SaveChangesAsync();
            return valoracion;
        }

        public async Task<bool> UpdateAsync(Valoracion valoracion)
        {
            _context.Valoraciones.Update(valoracion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var valoracion = await _context.Valoraciones.FindAsync(id);
            if (valoracion == null)
                return false;

            _context.Valoraciones.Remove(valoracion);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

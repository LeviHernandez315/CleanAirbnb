using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.TelefonoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class TelefonoRepository: ITelefonoRepository
    {
        private readonly BackendDBContext _context;

        public TelefonoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllAsync()
        {
            return await _context.Telefonos.ToListAsync();
        }

        public async Task<Telefono?> GetByIdAsync(int id)
        {
            return await _context.Telefonos.FindAsync(id);
        }

        public async Task<Telefono> CreateAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> UpdateAsync(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null)
                return false;

            _context.Telefonos.Remove(telefono);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

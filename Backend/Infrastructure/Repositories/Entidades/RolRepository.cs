﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.RolInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.Entidades
{
    public class RolRepository: IRolRepository
    {
        private readonly BackendDBContext _context;

        public RolRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task AddAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}

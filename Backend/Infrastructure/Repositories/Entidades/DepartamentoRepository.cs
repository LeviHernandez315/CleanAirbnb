using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Entidades.DepartamentoInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entidades
{
    public class DepartamentoRepository : IDepartamentoRepository
    {

        private readonly BackendDBContext _context;

        public DepartamentoRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var departamento = await _context.AreasTrabajo.FindAsync(id);
            if (departamento is null) return false;

            _context.AreasTrabajo.Remove(departamento);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> GetByIdAsync(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class EstadoRepository
    {
        public readonly AppDbContext _context;
        
        public async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task<Estado?> GetByIdAsync(int id)
        {
            return await _context.Estados.FindAsync(id);
        }

        public async Task<Estado?> GetByNameAsync(string nomeEstado)
        {
            return await _context.Estados.FirstOrDefaultAsync(e => e.NomeEstado == nomeEstado);
        }

        public async Task<Estado> AddAsync(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<Estado> UpdateAsync(Estado estado)
        {
            _context.Entry(estado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task DeleteAsync(Estado estado)
        {
            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
        }
    }
}

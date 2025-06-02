using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class AlertaRepository
    {
        public readonly AppDbContext _context;
        public AlertaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Alerta>> GetAllAsync()
        {
            return await _context.Alerta.ToListAsync();
        }
        public async Task<Alerta?> GetByIdAsync(int id)
        {
            return await _context.Alerta.FindAsync(id);
        }
        public async Task<Alerta> AddAsync(Alerta alerta)
        {
            _context.Alerta.Add(alerta);
            await _context.SaveChangesAsync();
            return alerta;
        }
        public async Task<Alerta> UpdateAsync(Alerta alerta)
        {
            _context.Entry(alerta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return alerta;
        }
        public async Task DeleteAsync(Alerta alerta)
        {
            _context.Alerta.Remove(alerta);
            await _context.SaveChangesAsync();
        }
    }
}

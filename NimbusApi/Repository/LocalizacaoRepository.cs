using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class LocalizacaoRepository
    {
        private readonly AppDbContext _context;

        public LocalizacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Localizacao>> GetAllAsync()
        {
            return await _context.Localizacao.ToListAsync();
        }
        public async Task<Localizacao?> GetByIdAsync(int id)
        {
            return await _context.Localizacao.FindAsync(id);
        }
        public async Task<Localizacao> AddAsync(Localizacao localizacao)
        {
            _context.Localizacao.Add(localizacao);
            await _context.SaveChangesAsync();
            return localizacao;
        }
        public async Task<Localizacao> UpdateAsync(Localizacao localizacao)
        {
            _context.Entry(localizacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return localizacao;
        }
        public async Task DeleteAsync(Localizacao localizacao)
        {
            _context.Localizacao.Remove(localizacao);
            await _context.SaveChangesAsync();
        }
    }
}

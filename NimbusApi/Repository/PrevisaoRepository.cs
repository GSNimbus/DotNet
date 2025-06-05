using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class PrevisaoRepository
    {
        private readonly AppDbContext _context;

        public PrevisaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Previsao>> GetAllAsync()
        {
            return await _context.Previsao.ToListAsync();
        }

        public async Task<Previsao?> GetByIdAsync(int id)
        {
            return await _context.Previsao.FindAsync(id);
        }
        public async Task<Previsao?> GetByCidadeIdAsync(int idBairro)
        {
            return await _context.Previsao.Where(p => p.IdBairro == idBairro).ToListAsync();
        }

        public async Task<Previsao> AddAsync(Previsao previsao)
        {
            _context.Previsao.Add(previsao);
            await _context.SaveChangesAsync();
            return previsao;
        }

        public async Task<Previsao> UpdateAsync(Previsao previsao)
        {
            _context.Entry(previsao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return previsao;
        }

        public async Task DeleteAsync(Previsao previsao)
        {
            _context.Previsao.Remove(previsao);
            await _context.SaveChangesAsync();
        }
    }
}

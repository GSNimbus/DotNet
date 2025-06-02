using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class CidadeRepository
    {

        private readonly AppDbContext _context;
        public CidadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cidade>> GetAllAsync()
        {
            return await _context.Cidades.ToListAsync();
        }

        public async Task<Cidade?> GetByIdAsync(int id)
        {
            return await _context.Cidades.FindAsync(id);
        }

        public async Task<Cidade?> GetByNameAsync(string nomeCidade)
        {
            return await _context.Cidades.FirstOrDefaultAsync(c => c.NomeCidade == nomeCidade);
        }

        public async Task<Cidade> AddAsync(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();
            return cidade;
        }

        public async Task<Cidade> UpdateAsync(Cidade cidade)
        {
            _context.Entry(cidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cidade;
        }

        public async Task DeleteAsync(Cidade cidade)
        {
            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();
        }

    }
}

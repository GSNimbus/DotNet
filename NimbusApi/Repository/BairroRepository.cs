using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class BairroRepository
    {
        private readonly AppDbContext _context;

        public BairroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bairro>> GetAllAsync()
        {
            return await _context.Bairro.ToListAsync();
        }
        public async Task<Bairro?> GetByIdAsync(int id)
        {
            return await _context.Bairro.FindAsync(id);
        }
        public async Task<Bairro?> GetByNameAsync(string nomeBairro)
        {
            if (string.IsNullOrEmpty(nomeBairro))
            {
                throw new ArgumentException("O nome do bairro não pode ser nulo ou vazio.");
            }
            return await _context.Bairro.FirstOrDefaultAsync(b => b.Logradouro == nomeBairro);
        }
        public async Task<Bairro> AddAsync(Bairro bairro)
        {
            _context.Bairro.Add(bairro);
            await _context.SaveChangesAsync();
            return bairro;
        }
        public async Task<Bairro> UpdateAsync(Bairro bairro)
        {
            _context.Entry(bairro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bairro;
        }
        public async Task DeleteAsync(Bairro bairro)
        {
            _context.Bairro.Remove(bairro);
            await _context.SaveChangesAsync();
        }
    }
}

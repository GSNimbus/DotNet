using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class PaisRepository
    {
        private readonly AppDbContext _context;
        public PaisRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task <IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Pais.ToListAsync();
        }
        public async Task<Pais?> GetByIdAsync(int id)
        {
            return await _context.Pais.FindAsync(id);
        }

        public async Task<Pais> AddAsync(Pais pais)
        {
            Console.WriteLine(pais);
            _context.Pais.Add(pais);
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> UpdateAsync(Pais pais)
        {
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task DeleteAsync(Pais pais)
        {
            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();
        }

        public async Task<Pais?> GetByNameAsync(string nomePais)
        {
            return await _context.Pais.FirstOrDefaultAsync(p => p.NomePais == nomePais);
        }
    }
}

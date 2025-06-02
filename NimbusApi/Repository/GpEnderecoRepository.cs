using Microsoft.EntityFrameworkCore;
using NimbusApi.Connection;
using NimbusApi.Models;

namespace NimbusApi.Repository
{
    public class GpEnderecoRepository
    {
        public readonly AppDbContext _context;

        public async Task<IEnumerable<GpEndereco>> GetAllAsync()
        {
            return await _context.GpEnderecos.ToListAsync();
        }
        public async Task<GpEndereco?> GetByIdAsync(int id)
        {
            return await _context.GpEnderecos.FindAsync(id);
        }
        public async Task<GpEndereco?> GetByNomeGrupo(string nome)
        {
            return await _context.GpEnderecos.FirstOrDefaultAsync(e => e.NmGrupo == nome);
        }

        public async Task<GpEndereco> AddAsync(GpEndereco gpEndereco)
        {
            _context.GpEnderecos.Add(gpEndereco);
            await _context.SaveChangesAsync();
            return gpEndereco;
        }

        public async Task<GpEndereco> UpdateAsync(GpEndereco gpEndereco)
        {
            _context.Entry(gpEndereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gpEndereco;
        }

        public async Task DeleteAsync(GpEndereco gpEndereco)
        {
            _context.GpEnderecos.Remove(gpEndereco);
            await _context.SaveChangesAsync();
        }
    }
}

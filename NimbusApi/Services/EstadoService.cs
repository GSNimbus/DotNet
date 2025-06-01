using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class EstadoService
    {
        public readonly EstadoRepository _Repository;
        public EstadoService(EstadoRepository repository)
        {
            _Repository = repository;
        }
        public async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
        public async Task<Estado?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _Repository.GetByIdAsync(id);
        }

        public async Task<Estado?> GetByNameAsync(string nomeEstado)
        {
            if (string.IsNullOrEmpty(nomeEstado))
            {
                throw new ArgumentException("O nome do estado não pode ser nulo ou vazio.");
            }
            return await _Repository.GetByNameAsync(nomeEstado);
        }

        public async Task<Estado> AddAsync(Estado estado)
        {
            if (estado == null)
            {
                throw new ArgumentNullException(nameof(estado), "O objeto Estado não pode ser nulo.");
            }
            EstadoValidation.ValideEstado(estado);
            return await _Repository.AddAsync(estado);
        }

        public async Task<Estado> UpdateAsync(int id, Estado estado)
        {
            if (id != estado.IdEstado)
            {
                throw new ArgumentException("O ID do estado não corresponde ao ID fornecido.");
            }
            EstadoValidation.ValideEstado(estado);
            return await _Repository.UpdateAsync(estado);
        }

        public async Task DeleteAsync(int id)
        {
            var estado = await _Repository.GetByIdAsync(id);
            if (estado == null)
            {
                throw new KeyNotFoundException("Estado não encontrado.");
            }
            await _Repository.DeleteAsync(estado);
        }
    }
}

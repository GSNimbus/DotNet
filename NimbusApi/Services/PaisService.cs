using NimbusApi.Exceptions;
using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class PaisService
    {
        public readonly PaisRepository _repository;

        public PaisService(PaisRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Pais?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Pais?> GetByNameAsync(string nomePais)
        {
            if (string.IsNullOrEmpty(nomePais))
            {
                throw new ArgumentException("O nome do país não pode ser nulo ou vazio.");
            }
            return await _repository.GetByNameAsync(nomePais);
        }

        public async Task<Pais> AddAsync(Pais pais)
        {
            if (pais == null)
            {
                throw new ArgumentNullException(nameof(pais), "O objeto Pais não pode ser nulo.");
            }
            PaisValidation.ValidePais(pais);
            return await _repository.AddAsync(pais);
        }

        public async Task<Pais> UpdateAsync(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                throw new ArgumentException("O ID do país não corresponde ao ID fornecido.");
            }
            PaisValidation.ValidePais(pais);
            return await _repository.UpdateAsync(pais);
        }
        public async Task DeleteAsync(int id)
        {
            var pais = await _repository.GetByIdAsync(id);
            if (pais == null)
            {
                throw new NotFoundException("País não encontrado.");
            }
            await _repository.DeleteAsync(pais);
        }
    }
}

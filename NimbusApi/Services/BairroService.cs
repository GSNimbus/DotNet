using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class BairroService
    {
        public readonly BairroRepository _repository;

        public async Task<IEnumerable<Bairro>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Bairro?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Bairro?> GetByNameAsync(string nomeBairro)
        {
            if (string.IsNullOrEmpty(nomeBairro))
            {
                throw new ArgumentException("O nome do bairro não pode ser nulo ou vazio.");
            }
            return await _repository.GetByNameAsync(nomeBairro);
        }

        public async Task<Bairro> AddAsync(Bairro bairro)
        {
            if (bairro == null)
            {
                throw new ArgumentException("O objeto Bairro não pode ser nulo.");
            }
            BairroValidation.ValideBairro(bairro);
            return await _repository.AddAsync(bairro);
        }

        public async Task<Bairro> UpdateAsync(int id, Bairro bairro)
        {
            if (id != bairro.IdBairro)
            {
                throw new ArgumentException("O ID do bairro não corresponde ao ID fornecido.");
            }
            BairroValidation.ValideBairro(bairro);
            return await _repository.UpdateAsync(bairro);
        }

        public async Task DeleteAsync(int id)
        {
            var bairro = await _repository.GetByIdAsync(id);
            if (bairro == null)
            {
                throw new KeyNotFoundException("Bairro não encontrado.");
            }
            await _repository.DeleteAsync(bairro);
        }

    }
}

using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class CidadeService
    {

        public readonly CidadeRepository _repository;

        public async Task<IEnumerable<Cidade>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cidade?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Cidade?> GetByNameAsync(string nomeCidade)
        {
            if (string.IsNullOrEmpty(nomeCidade))
            {
                throw new ArgumentException("O nome da cidade não pode ser nulo ou vazio.");
            }
            return await _repository.GetByNameAsync(nomeCidade);
        }

        public async Task<Cidade> AddAsync(Cidade cidade)
        {
            if (cidade == null)
            {
                throw new ArgumentNullException(nameof(cidade), "O objeto Cidade não pode ser nulo.");
            }
            CidadeValidation.ValideCidade(cidade);
            return await _repository.AddAsync(cidade);
        }

        public async Task<Cidade> UpdateAsync(int id, Cidade cidade)
        {
            if (id != cidade.IdCidade)
            {
                throw new ArgumentException("O ID da cidade não corresponde ao ID fornecido.");
            }
            CidadeValidation.ValideCidade(cidade);
            return await _repository.UpdateAsync(cidade);
        }

        public async Task DeleteAsync(int id)
        {
            var cidade = await _repository.GetByIdAsync(id);
            if (cidade == null)
            {
                throw new ArgumentException("Cidade não encontrada.");
            }
            await _repository.DeleteAsync(cidade);
        }
    }
}

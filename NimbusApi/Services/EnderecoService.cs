using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class EnderecoService
    {
        public readonly EnderecoRepository _repository;
        public EnderecoService(EnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Endereco?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Endereco?> GetByCepAsync(string cep)
        {
            if (string.IsNullOrEmpty(cep))
            {
                throw new ArgumentException("O CEP não pode ser nulo ou vazio.");
            }
            return await _repository.GetByCepAsync(cep);
        }

        public async Task<Endereco> AddAsync(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "O objeto Endereco não pode ser nulo.");
            }
            EnderecoValidation.Validate(endereco);
            return await _repository.AddAsync(endereco);
        }

        public async Task<Endereco> UpdateAsync(int id, Endereco endereco)
        {
            if (id != endereco.IdEndereco)
            {
                throw new ArgumentException("O ID do endereço não corresponde ao ID fornecido.");
            }
            EnderecoValidation.Validate(endereco);
            return await _repository.UpdateAsync(endereco);
        }

        public async Task DeleteAsync(int id)
        {
            var endereco = await _repository.GetByIdAsync(id);
            if (endereco == null)
            {
                throw new ArgumentException("Endereço não encontrado.");
            }
            await _repository.DeleteAsync(endereco);
        }
    }
}

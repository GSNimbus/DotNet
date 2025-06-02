using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class GpEnderecoService
    {
        public readonly GpEnderecoRepository _repository;

        public GpEnderecoService(GpEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GpEndereco>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GpEndereco?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<GpEndereco?> GetByNomeGrupo(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio.");
            }
            return await _repository.GetByNomeGrupo(nome);
        }
        public async Task<GpEndereco> AddAsync(GpEndereco gpEndereco)
        {
            if (gpEndereco == null)
            {
                throw new ArgumentNullException(nameof(gpEndereco), "O objeto GpEndereco não pode ser nulo.");
            }
            GpEnderecoValidation.ValideGpEndereco(gpEndereco);
            return await _repository.AddAsync(gpEndereco);
        }

        public async Task<GpEndereco> UpdateAsync(int id, GpEndereco gpEndereco)
        {
            if (id != gpEndereco.IdGpEndereco)
            {
                throw new ArgumentException("O ID do GpEndereco não corresponde ao ID fornecido.");
            }
            GpEnderecoValidation.ValideGpEndereco(gpEndereco);
            return await _repository.UpdateAsync(gpEndereco);
        }

        public async Task DeleteAsync(int id)
        {
            var gpEndereco = await _repository.GetByIdAsync(id);
            if (gpEndereco == null)
            {
                throw new KeyNotFoundException("GpEndereco não encontrado.");
            }
            await _repository.DeleteAsync(gpEndereco);
        }

    }
}

using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class LocalizacaoService
    {
        public readonly LocalizacaoRepository _repository;

        public LocalizacaoService(LocalizacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Localizacao>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Localizacao?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Localizacao> AddAsync(Localizacao localizacao)
        {
            if (localizacao == null)
            {
                throw new ArgumentNullException(nameof(localizacao), "O objeto Localizacao não pode ser nulo.");
            }
            LocalizacaoValidation.ValideLocalizacao(localizacao);
            return await _repository.AddAsync(localizacao);
        }

        public async Task<Localizacao> UpdateAsync(int id, Localizacao localizacao)
        {
            if (id != localizacao.IdLocalizacao)
            {
                throw new ArgumentException("O ID da localização não corresponde ao ID fornecido.");
            }
            LocalizacaoValidation.ValideLocalizacao(localizacao);
            return await _repository.UpdateAsync(localizacao);
        }

        public async Task DeleteAsync(int id)
        {
            var localizacao = await _repository.GetByIdAsync(id);
            if (localizacao == null)
            {
                throw new KeyNotFoundException("Localização não encontrada.");
            }
            await _repository.DeleteAsync(localizacao);
        }
    }
}

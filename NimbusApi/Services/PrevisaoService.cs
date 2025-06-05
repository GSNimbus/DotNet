namespace NimbusApi.Services
{
    public class PrevisaoService
    {
        private readonly PrevisaoRepository _previsaoRepository;

        public PrevisaoService(PrevisaoRepository previsaoRepository)
        {
            _previsaoRepository = previsaoRepository;
        }

        public async Task<IEnumerable<Previsao>> GetAllAsync()
        {
            return await _previsaoRepository.GetAllAsync();
        }

        public async Task<Previsao?> GetByIdAsync(int id)
        {
            return await _previsaoRepository.GetByIdAsync(id);
        }

        public async Task<Previsao> AddAsync(Previsao previsao)
        {
            return await _previsaoRepository.AddAsync(previsao);
        }

        public async Task<Previsao> UpdateAsync(Previsao previsao)
        {
            return await _previsaoRepository.UpdateAsync(previsao);
        }

        public async Task DeleteAsync(Previsao previsao)
        {
            await _previsaoRepository.DeleteAsync(previsao);
        }
    }
}

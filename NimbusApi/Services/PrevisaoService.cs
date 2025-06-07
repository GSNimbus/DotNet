using NimbusApi.Models;
using NimbusApi.Repository;
using System.Text;
using System.Text.Json;

namespace NimbusApi.Services
{
    public class PrevisaoService
    {
        private readonly PrevisaoRepository _previsaoRepository;
        private readonly AlertaRepository _alertaRepository;

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/alerta")
        };

        public PrevisaoService(PrevisaoRepository previsaoRepository, AlertaRepository alertaRepository)
        {
            _previsaoRepository = previsaoRepository;
            _alertaRepository = alertaRepository;
        }

        public async Task<IEnumerable<Previsao>> GetAllAsync()
        {
            return await _previsaoRepository.GetAllAsync();
        }

        public async Task<Previsao?> GetByIdAsync(int id)
        {
            return await _previsaoRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Previsao>> GetByBairroAsync(int id)
        {
            return await _previsaoRepository.GetByBairroIdAsync(id);
        }
        public async Task<Alerta> Prever(PreverCorpo obj,int id)
        {
            var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/alerta", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao prever: StatusCode={response.StatusCode}, Conteúdo={responseContent}");
            }
            if (string.IsNullOrEmpty(responseContent))
            {
                throw new Exception($"Erro ao prever: {responseContent}");
            }

            var respostaPrever = JsonSerializer.Deserialize<RespostaPrever>(responseContent);
            if (respostaPrever == null)
            {
                throw new Exception("Erro ao prever: Falha ao desserializar a resposta.");
            }
            var alerta = new Alerta
            {
                Risco = respostaPrever.risco,
                Descricao = respostaPrever.debug_info_precipitacao.ToString() ?? "Sem descrição disponivel",
                Mensagem = respostaPrever.mensagem,
                IdBairro = id,
                DataHora = DateTime.Now
            };
            if (respostaPrever != null)
            {  
                await _alertaRepository.AddAsync(alerta);
            }

            return alerta;
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

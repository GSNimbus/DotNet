using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class GpEnderecoService
    {
        public readonly GpEnderecoRepository _repository;
        public readonly PrevisaoService _previsaoService;
        public readonly EnderecoService _enderecoService;

        public GpEnderecoService(GpEnderecoRepository repository, PrevisaoService previsaoService,EnderecoService enderecoService)
        {
            _repository = repository;
            _previsaoService = previsaoService;
            _enderecoService = enderecoService;
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
        public async Task<IEnumerable<GpEndereco>> GetByIdUsuarioAsync(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new ArgumentException("O ID do usuário não pode ser zero ou negativo.");
            }
            return await _repository.GetByUsuarioIdAsync(idUsuario);
        }

        public async Task<GpEndereco> AddAsync(GpEndereco gpEndereco)
        {
            if (gpEndereco == null)
            {
                throw new ArgumentNullException(nameof(gpEndereco), "O objeto GpEndereco não pode ser nulo.");
            }
            GpEnderecoValidation.ValideGpEndereco(gpEndereco);
            var previsaoMocada = new PreverCorpo
            {
                temperature2_m = 20,
                relative_humidity2_m = 20,
                surface_pressure = 20,
                apparent_temperature = 20,
                wind_speed10_m = 20,
                Mes = 1,
                DiaDoAno = 1,
                HoraDoDia = 1
            };
            var endereco = await _enderecoService.GetByIdAsync(gpEndereco.IdEndereco);
            if (endereco == null)
            {
                throw new KeyNotFoundException("Endereço não encontrado.");
            }
            var previsao = await _previsaoService.Prever(previsaoMocada, endereco.IdBairro);
            if (previsao == null)
            {
                throw new Exception("Erro ao prever as condições climáticas.");
            }
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

using NimbusApi.Models;
using NimbusApi.Repository;

namespace NimbusApi.Services
{
    public class AlertaService
    {
        public readonly AlertaRepository _alertaRepository;
        public AlertaService(AlertaRepository alertaRepository)
        {
            _alertaRepository = alertaRepository;
        }

        public async Task<IEnumerable<Alerta>> GetAllAsync()
        {
            return await _alertaRepository.GetAllAsync();
        }
        public async Task<Alerta?> GetByIdAsync(int id)
        {
            return await _alertaRepository.GetByIdAsync(id);
        }
        public async Task<Alerta> AddAsync(Alerta alerta)
        {
            if (alerta == null)
            {
                throw new ArgumentException("O objeto Alerta não pode ser nulo.");
            }
            Validations.AlertaValidation.ValideAlerta(alerta);
            return await _alertaRepository.AddAsync(alerta);
        }
        public async Task<Alerta> UpdateAsync(Alerta alerta)
        {
            if (alerta == null)
            {
                throw new ArgumentException("O objeto Alerta não pode ser nulo.");
            }
            Validations.AlertaValidation.ValideAlerta(alerta);
            return await _alertaRepository.UpdateAsync(alerta);
        }
        public async Task DeleteAsync(Alerta alerta)
        {
            if (alerta == null)
            {
                throw new ArgumentException("O objeto Alerta não pode ser nulo.");
            }
            await _alertaRepository.DeleteAsync(alerta);
        }
    }
}

using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;

namespace NimbusApi.Services
{
    public class UsuarioService
    {
        public readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("O email não pode ser nulo ou vazio.");
            }
            return await _repository.GetByEmailAsync(email);
        }
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "O objeto Usuario não pode ser nulo.");
            }
            UsuarioValidation.ValideUsuario(usuario);
            return await _repository.AddAsync(usuario);
        }
        public async Task<Usuario> UpdateAsync(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                throw new ArgumentException("O ID do usuário não corresponde ao ID fornecido.");
            }
            UsuarioValidation.ValideUsuario(usuario);
            return await _repository.UpdateAsync(usuario);
        }
        public async Task DeleteAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }
            await _repository.DeleteAsync(id);
        }


    }
}

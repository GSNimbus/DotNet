using NimbusApi.Models;
using NimbusApi.Repository;
using NimbusApi.Validations;
using System.Runtime.ConstrainedExecution;

namespace NimbusApi.Services
{
    public class UsuarioService
    {
        public readonly UsuarioRepository _repository;
        public readonly PaisRepository _paisRepository;
        public readonly EstadoRepository _estadoRepository;
        public readonly CidadeRepository _cidadeRepository;
        public readonly LocalizacaoRepository _localizacaoRepository;
        public readonly BairroRepository _bairroRepository;
        public readonly EnderecoRepository _enderecoRepository;
        public readonly GpEnderecoRepository _gpEnderecoRepository;

        public UsuarioService(UsuarioRepository repository, PaisRepository paisRepository, EstadoRepository estadoRepository, CidadeRepository cidadeRepository, LocalizacaoRepository localizacaoRepository, BairroRepository bairroRepository, EnderecoRepository enderecoRepository, GpEnderecoRepository gpEnderecoRepository)
        {
            _repository = repository;
            _paisRepository = paisRepository;
            _estadoRepository = estadoRepository;
            _cidadeRepository = cidadeRepository;
            _localizacaoRepository = localizacaoRepository;
            _bairroRepository = bairroRepository;
            _enderecoRepository = enderecoRepository;
            _gpEnderecoRepository = gpEnderecoRepository;

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

        public async Task<Usuario> AddAllAsync(ObjetoAddUser obj)
        {
            
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "O objeto não pode ser nulo.");
            }
            var pais = obj.Pais;
            var paisRes = await _paisRepository.GetByNameAsync(pais);
            if (paisRes == null)
            {
                paisRes = await _paisRepository.AddAsync(new Pais { NomePais = pais });
            }
            var estado = obj.Estado;
            var estadoRes = await _estadoRepository.GetByNameAsync(estado);
            if (estadoRes == null)
            {
                estadoRes = await _estadoRepository.AddAsync(new Estado { NomeEstado = estado, IdPais = paisRes.Id });
            }
            var cidade = obj.Cidade;
            var cidadeRes = await _cidadeRepository.GetByNameAsync(cidade);
            if (cidadeRes == null)
            {
                cidadeRes = await _cidadeRepository.AddAsync(new Cidade { NomeCidade = cidade, IdEstado = estadoRes.IdEstado });
            }
            var bairro = obj.Bairro;
            var bairroRes = await _bairroRepository.GetByNameAsync(bairro);
            if (bairroRes == null)
            {
                var localizacaoRes = await _localizacaoRepository.AddAsync(new Localizacao
                {
                    Longitude = obj.Longitude,
                    Latitude = obj.Latitude,
                });
                if (localizacaoRes == null)
                {
                    throw new Exception("Erro ao adicionar a localização.");
                }
                bairroRes = await _bairroRepository.AddAsync(new Bairro { Logradouro = bairro, IdCidade = cidadeRes.IdCidade, IdLocalizacao=localizacaoRes.IdLocalizacao });
            }
            var endereco = new Endereco
            {
                Cep = obj.Cep,
                IdBairro = bairroRes.IdBairro,
            };
            var enderecoRes = await _enderecoRepository.GetByCepAsync(endereco.Cep);
            if (enderecoRes == null)
            {
                enderecoRes = await _enderecoRepository.AddAsync(endereco);
            }
            var usuario = new Usuario
            {
                Nome = obj.Nome,
                Email = obj.Email,
                Senha = obj.Senha,
            };
            var usuarioRes = await _repository.GetByEmailAsync(usuario.Email);
            if (usuarioRes != null)
            {
                throw new ArgumentException("Já existe um usuário com este email.");
            }
            UsuarioValidation.ValideUsuario(usuario);
            usuarioRes = await _repository.AddAsync(usuario);
            if (usuarioRes == null)
            {
                throw new Exception("Erro ao adicionar o usuário.");
            }
            var grupoLocalizacao = new GpEndereco
            {
                NmGrupo = "Localização do usuário",
                IdUsuario = usuarioRes.IdUsuario,
                IdEndereco = enderecoRes.IdEndereco,
            };
            var gpEnderecoRes = await _gpEnderecoRepository.AddAsync(grupoLocalizacao);
            if (gpEnderecoRes == null)
            {
                throw new Exception("Erro ao adicionar o grupo de endereços.");
            }
            return usuarioRes;
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

using NimbusApi.Exceptions;
using NimbusApi.Models;

namespace NimbusApi.Validations
{
    public class GpEnderecoValidation
    {
        public static void ValideGpEndereco(GpEndereco gpEndereco)
        {
            if (gpEndereco == null)
            {
                throw new ArgumentNullException(nameof(gpEndereco), "O objeto GpEndereco não pode ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(gpEndereco.NmGrupo))
            {
                throw new ArgumentException("O nome do grupo não pode ser vazio ou nulo.", nameof(gpEndereco.NmGrupo));
            }
            if (gpEndereco.NmGrupo.Length > 100)
            {
                throw new TamanhoInvalidoException(100,"NmGrupo");
            }
            if (gpEndereco.IdUsuario <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gpEndereco.IdUsuario), "O ID do usuário deve ser um valor positivo.");
            }
            if (gpEndereco.IdEndereco <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gpEndereco.IdEndereco), "O ID do endereço deve ser um valor positivo.");
            }
        }
    }
}

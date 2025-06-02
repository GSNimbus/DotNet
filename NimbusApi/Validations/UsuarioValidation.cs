using NimbusApi.Exceptions;

namespace NimbusApi.Validations
{
    public class UsuarioValidation
    {
        public static bool ValideUsuario(Models.Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
            {
                throw new ArgumentException("O email do usuário é inválido.");
            }
            if (!usuario.Email.Contains("@"))
            {
                throw new EmailInvalidoException();
            }
            if (string.IsNullOrWhiteSpace(usuario.Senha) || usuario.Senha.Length < 6)
            {
                throw new ArgumentException("A senha do usuário deve ter pelo menos 6 caracteres.");
            }
            return true;
        }
    }
}

using NimbusApi.Exceptions;
using NimbusApi.Models;

namespace NimbusApi.Validations
{
    public class BairroValidation
    {
        public static void ValideBairro(Bairro bairro)
        {
            if (string.IsNullOrEmpty(bairro.Logradouro))
            {
                throw new ArgumentException("O logradouro não pode ser nulo ou vazio.");
            }
            if (bairro.Logradouro.Length > 100)
            {
                throw new TamanhoInvalidoException(100, "Logradouro");
            }
            if (bairro.IdCidade <= 0)
            {
                throw new ArgumentException("O Id da cidade deve ser um valor positivo.");
            }
            if (bairro.IdLocalizacao <= 0)
            {
                throw new ArgumentException("O Id da localização deve ser um valor positivo.");
            }
        }
    }
}

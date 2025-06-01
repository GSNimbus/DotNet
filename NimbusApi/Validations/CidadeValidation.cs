using NimbusApi.Models;
using NimbusApi.Exceptions;

namespace NimbusApi.Validations
{
    public class CidadeValidation
    {
        public static void ValideCidade(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.NomeCidade))
            {
                throw new NomeObrigatorioException();
            }
            if (cidade.NomeCidade.Length > 100)
            {
                throw new TamanhoInvalidoException(100, "Cidade");
            }
            if (cidade.IdEstado <= 0)
            {
                throw new ArgumentException("O ID do estado associado à cidade deve ser maior que zero.");
            }
        }
    }
}

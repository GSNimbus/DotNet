using NimbusApi.Exceptions;
using NimbusApi.Models;


namespace NimbusApi.Validations
{
    public class PaisValidation
    {
        public static void ValidePais(Pais pais)
        {
            if (string.IsNullOrEmpty(pais.NomePais))
            {
                throw new NomeObrigatorioException();
            }
            if (pais.NomePais.Length > 100)
            {
                throw new TamanhoInvalidoException(100, "Pais");
            }
        }
    }
}

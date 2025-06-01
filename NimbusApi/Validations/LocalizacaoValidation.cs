using NimbusApi.Exceptions;
using NimbusApi.Models;

namespace NimbusApi.Validations
{
    public class LocalizacaoValidation
    {
        public static void ValideLocalizacao(Localizacao localizacao)
        {
            if (string.IsNullOrEmpty(localizacao.Longitude))
            {
                throw new ArgumentException("A longitude não pode ser nula ou vazia.");
            }
            if (localizacao.Longitude.Length > 50)
            {
                throw new TamanhoInvalidoException(50, "Longitude");
            }
            if (string.IsNullOrEmpty(localizacao.Latitude))
            {
                throw new ArgumentException("A latitude não pode ser nula ou vazia.");
            }
            if (localizacao.Latitude.Length > 50)
            {
                throw new TamanhoInvalidoException(50,"Latitude");
            }
        }
    }
}

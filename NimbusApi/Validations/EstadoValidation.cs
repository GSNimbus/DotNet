using NimbusApi.Models;
using NimbusApi.Exceptions;

namespace NimbusApi.Validations
{
    public class EstadoValidation
    {

        public static void ValideEstado(Estado estado)
        {
            if (string.IsNullOrEmpty(estado.NomeEstado))
            {
                throw new NomeObrigatorioException();
            }
            if (estado.NomeEstado.Length > 100)
            {
                throw new TamanhoInvalidoException(100, "Estado");
            }
            if (estado.IdPais <= 0)
            {
                throw new ArgumentException("O ID do país associado ao estado deve ser maior que zero.");
            }
        }
    }
}

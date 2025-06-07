using NimbusApi.Models;

namespace NimbusApi.Validations
{
    public class PrevisaoValidation
    {
        public static void ValidePrevisao(Previsao previsao)
        {

            if (previsao == null)
            {
                throw new ArgumentNullException(nameof(previsao), "Previsão não pode ser nula");
            }
            if (previsao.Temperatura < -100 || previsao.Temperatura > 100)
            {
                throw new ArgumentOutOfRangeException("Temperatura deve estar entre -100 e 100 graus Celsius");
            }

            if (previsao.IdBairro <= 0)
            {
                throw new ArgumentException("Id bairro não pode ser 0");
            }

        }
    }
}

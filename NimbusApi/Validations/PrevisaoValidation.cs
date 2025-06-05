using NimbusApi.Models;

namespace NimbusApi.Validations
{
    public class PrevisaoValidation
    {
        public static void ValidePrevisao(Previsao previsao)
        {
            if (string.IsNullOrEmpty(previsao.DataPrevisao))
            {
                throw new Exceptions.DataObrigatoriaException();
            }
            if (previsao.TemperaturaMaxima < -100 || previsao.TemperaturaMaxima > 100)
            {
                throw new Exceptions.TemperaturaInvalidaException();
            }
            if (previsao.TemperaturaMinima < -100 || previsao.TemperaturaMinima > 100)
            {
                throw new Exceptions.TemperaturaInvalidaException();
            }
            if (previsao.IdBairro <= 0)
            {
                throw new Exceptions.CidadeObrigatoriaException();
            }

        }
    }
}

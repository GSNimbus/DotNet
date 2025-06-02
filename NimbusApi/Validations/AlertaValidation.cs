using NimbusApi.Exceptions;
using NimbusApi.Models;


namespace NimbusApi.Validations
{
    public class AlertaValidation
    {
        public static void ValideAlerta(Alerta alerta)
        {
            if (string.IsNullOrEmpty(alerta.Risco))
            {
                throw new ArgumentException("O risco não pode ser nulo ou vazio.");
            }
            if (alerta.Risco.Length > 50)
            {
                throw new TamanhoInvalidoException(50, "Risco");
            }
            if (string.IsNullOrEmpty(alerta.Descricao))
            {
                throw new ArgumentException("A descrição não pode ser nula ou vazia.");
            }
            if (alerta.Descricao.Length > 200)
            {
                throw new TamanhoInvalidoException(200, "Descrição");
            }
            if (string.IsNullOrEmpty(alerta.Mensagem))
            {
                throw new ArgumentException("A mensagem não pode ser nula ou vazia.");
            }
            if (alerta.Mensagem.Length > 500)
            {
                throw new TamanhoInvalidoException(500, "Mensagem");
            }
            if (alerta.IdLocalizacao <= 0)
            {
                throw new ArgumentException("O Id da localização deve ser um valor positivo.");
            }
        }
    }
}

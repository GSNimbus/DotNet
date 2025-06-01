
namespace NimbusApi.Exceptions
{
    public class NomeObrigatorioException : Exception
    {
        public NomeObrigatorioException() : base("O nome é obrigatório para realizar a gravação no sistema") { }
    }
}
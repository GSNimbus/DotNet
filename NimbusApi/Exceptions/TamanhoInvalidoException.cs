namespace NimbusApi.Exceptions
{
    public class TamanhoInvalidoException : Exception
    {
        public TamanhoInvalidoException(int maxLength,string nomeAtributo) : base($"O tamanho de {nomeAtributo} não pode ter mais de {maxLength} caracteres.") { }
    }
}

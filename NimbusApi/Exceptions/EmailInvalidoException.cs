namespace NimbusApi.Exceptions
{
    public class EmailInvalidoException : Exception
    {
        public EmailInvalidoException() : base("O email fornecido é inválido.") { }
        
        }
}

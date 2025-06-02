namespace NimbusApi.Validations
{
    public class EnderecoValidation
    {
        public static void Validate(Models.Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "Endereço não pode ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(endereco.Cep))
            {
                throw new ArgumentException("CEP não pode ser vazio ou nulo.", nameof(endereco.Cep));
            }
            if (endereco.IdBairro <= 0)
            {
                throw new ArgumentException("IdBairro deve ser um valor positivo.", nameof(endereco.IdBairro));
            }
            if (endereco.Cep.Length != 10)
            {
                throw new ArgumentException("CEP deve ter exatamente 10 caracteres.", nameof(endereco.Cep));
            }
        }
    }
}

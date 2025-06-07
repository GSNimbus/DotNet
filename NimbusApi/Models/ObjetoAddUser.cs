namespace NimbusApi.Models
{
    public class ObjetoAddUser
    {
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int NumLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Pais { get; set; }
    }
}

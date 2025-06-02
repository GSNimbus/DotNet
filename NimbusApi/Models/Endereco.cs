using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }

        public int IdBairro { get; set; }

        [JsonIgnore]
        public Bairro? Bairro { get; set; }
    }
}

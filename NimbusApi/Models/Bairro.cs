using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Bairro
    {
        public int IdBairro { get; set; }

        public string Logradouro { get; set; }


        public int IdCidade { get; set; }

        [JsonIgnore]
        public Cidade Cidade { get; set; }

        public int IdLocalizacao { get; set; }

        [JsonIgnore]
        public Localizacao Localizacao { get; set; }

        [JsonIgnore]
        public List<Endereco> Enderecos { get; set; } 
    }
}

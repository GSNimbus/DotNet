using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string NomeCidade { get; set; }
        public int IdEstado { get; set; }

        [JsonIgnore]
        public Estado Estado { get; set; }
    }
}

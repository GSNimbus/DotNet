using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Previsao
    {
        public int IdPrevisao { get; set; }

        public DateTime DataHora { get; set; }

        public float Temperatura { get; set; }

        public float Chuva { get; set; }
        
        public float CodigoChuva { get; set; } 

        public float VelocidadeVento { get; set; }

        public float RajadaVento { get; set; }

        public float Umidade { get; set; }

        public int IdBairro { get; set; }

        [JsonIgnore]
        public Bairro? Bairro { get; set; }
    }
}

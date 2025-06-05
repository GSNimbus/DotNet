using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Previsao
    {
        public int IdPrevisao { get; set; }

        public DateTime DataHora { get; set; }

        public int Temperatura { get; set; }

        public int Chuva { get; set; }
        
        public int CodigoChuva { get; set; } 

        public int VelocidadeVento { get; set; }

        public int RajadaVento { get; set; }

        public int Umidade { get; set; }

        public int IdBairro { get; set; }

        [JsonIgnore]
        public Bairro? Bairro { get; set; }
    }
}

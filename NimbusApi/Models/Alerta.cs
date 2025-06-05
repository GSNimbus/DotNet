using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Alerta
    {
        public int IdAlerta { get; set; }

        public String Risco { get; set; }

        public String Descricao { get; set; }

        public String Mensagem { get; set; }

        public DateTime DataHora { get; set; }

        public int IdBairro { get; set; }

        [JsonIgnore]
        public Bairro? Bairro { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Localizacao
    {

        public int IdLocalizacao { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        [JsonIgnore]
        public List<Alerta> Alertas { get; set; }
    }
}

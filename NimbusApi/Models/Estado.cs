using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }

        public int IdPais { get; set; }
        [JsonIgnore]
        public Pais Pais { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace NimbusApi.Models
{
    public class GpEndereco
    {
        public int IdGpEndereco { get; set; }

        public string NmGrupo { get; set; }

        public int IdUsuario { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        public int IdEndereco { get; set; }

        [JsonIgnore]
        public Endereco? Endereco { get; set; }

    }
}

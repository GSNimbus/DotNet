namespace NimbusApi.Models
{
    public class PreverCorpo
    {
        public float temperature2_m { get; set; }
        public float relative_humidity2_m { get; set; }
        public float surface_pressure { get; set; }
        public float apparent_temperature { get; set; }
        public float wind_speed10_m { get; set; }
        public int Mes { get; set; }
        public int DiaDoAno { get; set; }
        public int HoraDoDia { get; set; }
    }
}

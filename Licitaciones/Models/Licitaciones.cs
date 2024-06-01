namespace SupabaseApi.Models
{
    public class Licitacion
    {
        public string Nombre { get; set; } = string.Empty;
        public string organo_de_contratacion { get; set; } = string.Empty;
        public decimal importe { get; set; }
        public string CPV { get; set; } = string.Empty;
        public DateTime fecha_limite_presentacion { get; set; }
    }
}

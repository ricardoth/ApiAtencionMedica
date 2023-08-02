namespace AtencionMedica.Domain.Entities
{
    public class Complicacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComplicacion { get; set; }
        public string? NombreComplicacion { get; set; }
        public bool EsActivo { get; set; }
    }
}

namespace AtencionMedica.Domain.Entities
{
    public class Patologia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatologia { get; set; }    
        public string? NombrePatologia { get; set; }
        public bool EsActivo { get; set; }
    }
}

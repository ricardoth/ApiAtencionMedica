namespace AtencionMedica.Domain.Entities
{
    [Table("Comuna")]
    public class Comuna
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }
        public string Region { get; set; }
        public string SiglaRegion { get; set; }
        public bool EsActivo { get; set; }
    }
}

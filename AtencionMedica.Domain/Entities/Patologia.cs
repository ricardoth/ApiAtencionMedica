namespace AtencionMedica.Domain.Entities
{
    [Table("Patologia")]
    public class Patologia : BaseEntity
    {
        public string? NombrePatologia { get; set; }
        public virtual ICollection<PatologiaPaciente> PatologiaPacientes { get; set; }
    }
}

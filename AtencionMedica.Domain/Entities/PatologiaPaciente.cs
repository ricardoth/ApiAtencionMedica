namespace AtencionMedica.Domain.Entities
{
    [Table("PatologiaPaciente")]
    public class PatologiaPaciente : BaseEntity
    {
        [ForeignKey("IdPatologia")]
        public int IdPatologia { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public virtual Patologia Patologia { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}

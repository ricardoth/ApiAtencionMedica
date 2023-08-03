namespace AtencionMedica.Domain.Entities
{
    [Table("PatologiaPaciente")]
    public class PatologiaPaciente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPatologiaPaciente { get; set; }
        [ForeignKey("IdPatologia")]
        public int IdPatologia { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual Patologia Patologia { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}

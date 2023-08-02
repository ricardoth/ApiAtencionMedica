namespace AtencionMedica.Domain.Entities
{
    [Table("PatologiaPaciente")]
    public class PatologiaPaciente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdComplicacionPaciente { get; set; }
        [ForeignKey("IdComplicacion")]
        public int IdComplicacion { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual IEnumerable<Complicacion> Complicaciones { get; set; }
        public virtual IEnumerable<Paciente> Pacientes { get; set; }
    }
}

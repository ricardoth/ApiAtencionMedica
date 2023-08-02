namespace AtencionMedica.Domain.Entities
{
    [Table("ComplicacionPaciente")]
    public class ComplicacionPaciente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComplicacionPaciente { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        [ForeignKey("IdComplicacion")]
        public int IdComplicacion { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public virtual IEnumerable<Complicacion> Complicaciones { get; set; }
        public virtual IEnumerable<Paciente> Pacientes { get; set; }
    }
}

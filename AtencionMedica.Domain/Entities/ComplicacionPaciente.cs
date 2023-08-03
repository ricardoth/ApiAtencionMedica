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
        public virtual Complicacion Complicacion { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}

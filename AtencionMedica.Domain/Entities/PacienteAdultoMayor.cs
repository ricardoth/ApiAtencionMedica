namespace AtencionMedica.Domain.Entities
{
    [Table("PacienteAdultoMayor")]
    public class PacienteAdultoMayor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdultoMayor { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public bool AutoValente { get; set; }
        public bool Dependencia { get; set; }
        public virtual Paciente? Paciente { get; set; }
    }
}

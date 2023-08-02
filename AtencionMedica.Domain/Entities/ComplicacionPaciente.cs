namespace AtencionMedica.Domain.Entities
{
    public class ComplicacionPaciente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComplicacionPaciente { get; set; }
        public int IdPaciente { get; set; }
        public int IdComplicacion { get; set; }
        public virtual IEnumerable<Complicacion> Complicaciones { get; set; }
        public virtual IEnumerable<Paciente> Pacientes { get; set; }
    }
}

namespace AtencionMedica.Application.DTOs
{
    public class PacienteAdultoMayorGetDto
    {
        public int IdPacienteAdultoMayor { get; set; }
        public int IdPaciente { get; set; }
        public bool AutoValente { get; set; }
        public bool Dependencia { get; set; }
        public virtual PacienteDto? Paciente { get; set; }
    }
}

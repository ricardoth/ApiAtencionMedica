namespace AtencionMedica.Application.DTOs
{
    public class ComplicacionPacienteGetDto
    {
        public int IdComplicacionPaciente { get; set; }
        public int IdPaciente { get; set; }
        public int IdComplicacion { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public bool EsActivo { get; set; }
        public ComplicacionDto Complicacion { get; set; }
        public PacienteDto Paciente { get; set; }
    }
}

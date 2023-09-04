namespace AtencionMedica.Application.DTOs
{
    public class PatologiaPacienteDto
    {
        public int IdPatologiaPaciente { get; set; }
        public int IdPatologia { get; set; }
        public int IdPaciente { get; set; }
        public DateTime? FecComplicacion { get; set; }
        public bool EsActivo { get; set; }
    }
}

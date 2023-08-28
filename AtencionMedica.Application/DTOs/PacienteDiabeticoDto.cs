namespace AtencionMedica.Application.DTOs
{
    public class PacienteDiabeticoDto
    {
        public int IdPacienteDiabetico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime? FecEvaluacionDiabetes { get; set; }
        public bool Neuropatia { get; set; }
        public DateTime? FecNeuropatia { get; set; }
        public bool Amputacion { get; set; }
        public DateTime? FecAmputacion { get; set; }
        public bool Retinopatia { get; set; }
        public DateTime? FecRetinopatia { get; set; }
    }
}

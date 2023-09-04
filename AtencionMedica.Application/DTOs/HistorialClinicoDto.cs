namespace AtencionMedica.Application.DTOs
{
    public class HistorialClinicoDto
    {
        public int IdHistorialClinico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime? FechaHistorial { get; set; }
        public string? Diagnostico { get; set; }
        public string? Nota { get; set; }
        public bool EsActivo { get; set; }
    }
}

namespace AtencionMedica.Application.DTOs
{
    public class AgendaMedicoGetDto
    {
        public int IdAgendaMedico { get; set; }
        public int IdMedico { get; set; }
        public int IdEstadoAgendaMedico { get; set; }
        public DateTime? FecInicio { get; set; }
        public DateTime? FecFin { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public bool EsActivo { get; set; }
        public virtual MedicoDto Medico { get; set; }
        public virtual EstadoAgendaMedicoDto EstadoAgendaMedico { get; set; }
    }
}

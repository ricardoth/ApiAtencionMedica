namespace AtencionMedica.Domain.Entities
{
    public class AgendaMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAgendaMedico { get; set; }
        public int IdMedico { get; set; }
        public int IdEstadoAgendaMedico { get; set; }
        public DateTime? FecInicio { get; set; }
        public DateTime? FecFin { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual IEnumerable<Medico> Medicos { get; set; }    
        public virtual IEnumerable<EstadoAgendaMedico> EstadoAgendaMedicos { get; set; }
    }
}

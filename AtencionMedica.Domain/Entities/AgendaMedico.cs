namespace AtencionMedica.Domain.Entities
{
    [Table("AgendaMedico")]
    public class AgendaMedico : BaseEntity
    {
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }
        [ForeignKey("IdEstadoAgendaMedico")]
        public int IdEstadoAgendaMedico { get; set; }
        public DateTime? FecInicio { get; set; }
        public DateTime? FecFin { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual Medico Medico { get; set; }    
        public virtual EstadoAgendaMedico EstadoAgendaMedico { get; set; }
    }
}

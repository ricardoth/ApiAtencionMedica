namespace AtencionMedica.Domain.Entities
{
    [Table("EstadoAgendaMedico")]
    public class EstadoAgendaMedico : BaseEntity
    {
        public string? NombreEstadoAgendaMedico { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<AgendaMedico> AgendaMedicos { get; set; }
    }
}

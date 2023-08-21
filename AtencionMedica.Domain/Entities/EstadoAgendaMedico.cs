namespace AtencionMedica.Domain.Entities
{
    [Table("EstadoAgendaMedico")]
    public class EstadoAgendaMedico : BaseEntity
    {
        public string? NombreEstadoAgendaMedico { get; set; }
        public virtual ICollection<AgendaMedico> AgendaMedicos { get; set; }
    }
}

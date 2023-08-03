namespace AtencionMedica.Domain.Entities
{
    [Table("EstadoAgendaMedico")]
    public class EstadoAgendaMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoAgendaMedico { get; set; }
        public string? NombreEstadoAgendaMedico { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<AgendaMedico> AgendaMedicos { get; set; }
    }
}

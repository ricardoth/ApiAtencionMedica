namespace AtencionMedica.Domain.Entities
{
    [Table("EstadoFichaClinica")]
    public class EstadoFichaClinica : BaseEntity
    {
        public string? NombreEstadoFichaClinica { get; set; }
        public bool EsActivo { get; set; }
        public virtual ICollection<FichaClinica> FichaClinicas { get; set; }
    }
}

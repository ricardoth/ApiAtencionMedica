namespace AtencionMedica.Domain.Entities
{
    public class EstadoFichaClinica
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoFichaClinica { get; set; }
        public string? NombreEstadoFichaClinica { get; set; }
        public bool EsActivo { get; set; }
    }
}

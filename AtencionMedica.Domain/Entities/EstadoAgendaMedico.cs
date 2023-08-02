namespace AtencionMedica.Domain.Entities
{
    public class EstadoAgendaMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoAgendaMedico { get; set; }
        public string? NombreestadoAgendaMedico { get; set; }
        public bool EsActivo { get; set; }
    }
}

namespace AtencionMedica.Domain.Entities
{
    [Table("HistorialClinico")]
    public class HistorialClinico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdHistorialClinico { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public DateTime? FechaHistorial { get; set; }
        public string? Diagnostico { get; set; }
        public string? Nota { get; set;}
        public bool EsActivo { get; set;}
        public DateTime? FecCreacion { get; set;}
        public DateTime? FecActualizacion { get; set;}
        public virtual Paciente? Paciente { get; set; }
    }
}

namespace AtencionMedica.Domain.Entities
{
    [Table("HistorialClinico")]
    public class HistorialClinico : BaseEntity
    {
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public DateTime? FechaHistorial { get; set; }
        public string? Diagnostico { get; set; }
        public string? Nota { get; set;}
        public DateTime? FecCreacion { get; set;}
        public DateTime? FecActualizacion { get; set;}
        public virtual Paciente? Paciente { get; set; }
        public virtual ICollection<RecetaMedica> RecetaMedicas { get; set; }    
    }
}

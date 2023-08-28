namespace AtencionMedica.Domain.Entities
{
    [Table("RecetaMedica")]
    public class RecetaMedica : BaseEntity
    {
        [ForeignKey("IdHistorialClinico")]
        public int IdHistorialClinico { get; set; }
        [ForeignKey("IdMedicamento")]
        public int IdMedicamento { get; set; }
        public int Cantidad { get; set; }
        public string? Instrucciones { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FecInicio { get; set; } 
        public DateTime? FecFin { get; set; }
        public virtual HistorialClinico HistorialClinico { get; set; }
        public virtual Medicamento Medicamento { get; set; }

    }
}

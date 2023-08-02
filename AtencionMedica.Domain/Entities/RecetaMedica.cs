namespace AtencionMedica.Domain.Entities
{
    internal class RecetaMedica
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecetaMedica { get; set; }
        public long IdHistorialClinico { get; set; }
        public int IdMedicamento { get; set; }
        public decimal Cantidad { get; set; }
        public string? Instrucciones { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FecInicio { get; set; } 
        public DateTime? FecFin { get; set; }
        public bool EsActivo { get; set; }  
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual IEnumerable<HistorialClinico> HistorialesClinicos { get; set; }
        public virtual IEnumerable<Medicamento> Medicamentos { get; set; }

    }
}

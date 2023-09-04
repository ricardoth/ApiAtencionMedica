namespace AtencionMedica.Application.DTOs
{
    public class RecetaMedicaDto
    {
        public int IdRecetaMedica { get; set; }
        public int IdHistorialClinico { get; set; }
        public int IdMedicamento { get; set; }
        public int Cantidad { get; set; }
        public string? Instrucciones { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FecInicio { get; set; }
        public DateTime? FecFin { get; set; }
        public bool EsActivo { get; set; }
    }
}

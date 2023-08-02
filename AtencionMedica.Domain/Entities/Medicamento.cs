namespace AtencionMedica.Domain.Entities
{
    public class Medicamento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedicamento { get; set; }
        public string? NombreMedicamento { get; set; }
        public bool EsActivo { get; set; }
    }
}

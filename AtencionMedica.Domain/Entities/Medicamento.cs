namespace AtencionMedica.Domain.Entities
{
    [Table("Medicamento")]
    public class Medicamento : BaseEntity
    {
        public string? NombreMedicamento { get; set; }
        public bool EsActivo { get; set; }
        public virtual ICollection<RecetaMedica> RecetaMedicas { get; set; }

    }
}

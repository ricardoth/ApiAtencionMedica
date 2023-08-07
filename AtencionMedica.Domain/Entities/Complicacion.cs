namespace AtencionMedica.Domain.Entities
{
    [Table("Complicacion")]
    public class Complicacion : BaseEntity
    {
        public string? NombreComplicacion { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<ComplicacionPaciente> ComplicacionPacientes { get; set; }
    }
}

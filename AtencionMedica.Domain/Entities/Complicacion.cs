namespace AtencionMedica.Domain.Entities
{
    [Table("Complicacion")]
    public class Complicacion : BaseEntity
    {
        public string? NombreComplicacion { get; set; }
        public virtual ICollection<ComplicacionPaciente>? ComplicacionPacientes { get; set; }
    }
}

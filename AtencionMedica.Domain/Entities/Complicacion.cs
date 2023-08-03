namespace AtencionMedica.Domain.Entities
{
    [Table("Complicacion")]
    public class Complicacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComplicacion { get; set; }
        public string? NombreComplicacion { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<ComplicacionPaciente> ComplicacionPacientes { get; set; }
    }
}

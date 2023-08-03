namespace AtencionMedica.Domain.Entities
{
    [Table("Especialidad")]
    public class Especialidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<EspecialidadMedico> EspecialidadMedicos { get; set; }
    }
}

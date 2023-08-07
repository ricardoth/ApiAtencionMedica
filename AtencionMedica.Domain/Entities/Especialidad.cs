namespace AtencionMedica.Domain.Entities
{
    [Table("Especialidad")]
    public class Especialidad : BaseEntity
    {
        public string NombreEspecialidad { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<EspecialidadMedico> EspecialidadMedicos { get; set; }
    }
}

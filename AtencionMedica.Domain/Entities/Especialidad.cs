namespace AtencionMedica.Domain.Entities
{
    [Table("Especialidad")]
    public class Especialidad : BaseEntity
    {
        public string NombreEspecialidad { get; set; }
        public bool EsActivo { get; set; }
        public virtual ICollection<EspecialidadMedico> EspecialidadMedicos { get; set; }
    }
}

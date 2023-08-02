namespace AtencionMedica.Domain.Entities
{
    [Table("EspecialidadMedico")]
    public class EspecialidadMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidadMedico { get; set; }
        [ForeignKey("IdEspecialidad")]
        public int IdEspecialidad { get; set; }
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }
        public string CasaEstudio { get; set; }
        public DateTime FechaObtencionEspecialidad { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<Especialidad> Especialidades { get; set; }
        public virtual IEnumerable<Medico> Medicos { get; set; }
    }
}

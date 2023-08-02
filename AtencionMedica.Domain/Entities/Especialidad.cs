namespace AtencionMedica.Domain.Entities
{
    public class Especialidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public bool EsActivo { get; set; }
    }
}

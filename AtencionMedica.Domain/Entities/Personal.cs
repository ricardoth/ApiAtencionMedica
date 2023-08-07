namespace AtencionMedica.Domain.Entities
{
    [Table("Personal")]
    public class Personal : BaseEntity
    {
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }
        public virtual IEnumerable<FichaClinica> FichaClinicas { get; set; }
    }
}

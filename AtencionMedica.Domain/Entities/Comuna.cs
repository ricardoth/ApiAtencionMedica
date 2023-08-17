namespace AtencionMedica.Domain.Entities
{
    [Table("Comuna")]
    public class Comuna : BaseEntity
    {
        public string NombreComuna { get; set; }
        public string Region { get; set; }
        public string SiglaRegion { get; set; }
        public bool EsActivo { get; set; }
        public virtual ICollection<LugarAtencion> LugarAtenciones { get; set; }
    }
}

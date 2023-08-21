namespace AtencionMedica.Domain.Entities
{
    [Table("Modulo")]
    public class Modulo : BaseEntity
    {
        [ForeignKey("IdLugarAtencion")]
        public int IdLugarAtencion { get; set; }
        public string NombreModulo { get; set; }
        public string? Descripcion { get; set; }
        public virtual LugarAtencion LugarAtencion { get; set;}
        public virtual ICollection<FichaClinica> FichaClinicas { get; set; }    
    }
}

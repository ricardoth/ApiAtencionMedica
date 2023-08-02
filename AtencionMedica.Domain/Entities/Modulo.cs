namespace AtencionMedica.Domain.Entities
{
    [Table("Modulo")]
    public class Modulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModulo { get; set; }
        [ForeignKey("IdLugarAtencion")]
        public int IdLugarAtencion { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool EsActivo { get; set; }
        public virtual LugarAtencion LugarAtencion { get; set;}
    }
}

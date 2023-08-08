namespace AtencionMedica.Domain.Entities
{
    [Table("LugarAtencion")]
    public class LugarAtencion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLugarAtencion { get; set; }
        [ForeignKey("IdComuna")]
        public int IdComuna { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string HorarioAtencion { get; set; }
        public bool EsActivo { get; set; }
        public virtual Comuna Comuna { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }    
    }
}

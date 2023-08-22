namespace AtencionMedica.Domain.Entities
{
    [Table("LugarAtencion")]
    public class LugarAtencion : BaseEntity
    {
        [ForeignKey("IdComuna")]
        public int IdComuna { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string HorarioAtencion { get; set; }
        public virtual Comuna Comuna { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }    
    }
}

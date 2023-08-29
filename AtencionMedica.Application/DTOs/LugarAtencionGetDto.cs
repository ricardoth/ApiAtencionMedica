namespace AtencionMedica.Application.DTOs
{
    public class LugarAtencionGetDto
    {
        public int IdLugarAtencion { get; set; }
        public int IdComuna { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string HorarioAtencion { get; set; }
        public virtual ComunaDto Comuna { get; set; }
    }
}

namespace AtencionMedica.Application.DTOs
{
    public class LugarAtencionDto 
    {
        public int IdLugarAtencion { get; set; }
        public int IdComuna { get; set; }
        public string NombreLugar { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string HorarioAtencion { get; set; }
    }
}

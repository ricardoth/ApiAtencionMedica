namespace AtencionMedica.Application.DTOs
{
    public class ModuloGetDto
    {
        public int IdModulo { get; set; }
        public int IdLugarAtencion { get; set; }
        public string NombreModulo { get; set; }
        public string? Descripcion { get; set; }
        public virtual LugarAtencionDto LugarAtencion { get; set; }
    }
}

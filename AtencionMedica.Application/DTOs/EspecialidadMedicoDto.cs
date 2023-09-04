namespace AtencionMedica.Application.DTOs
{
    public class EspecialidadMedicoDto
    {
        public int IdEspecialidadMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdMedico { get; set; }
        public string CasaEstudio { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaObtencionEspecialidad { get; set; }
    }
}

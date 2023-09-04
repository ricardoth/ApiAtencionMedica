namespace AtencionMedica.Application.DTOs
{
    public class EspecialidadMedicoGetDto
    {
        public int IdEspecialidadMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdMedico { get; set; }
        public string CasaEstudio { get; set; }
        public DateTime FechaObtencionEspecialidad { get; set; }
        public bool EsActivo { get; set; }
        public virtual EspecialidadDto Especialidad { get; set; }
        public virtual MedicoDto Medico { get; set; }
    }
}

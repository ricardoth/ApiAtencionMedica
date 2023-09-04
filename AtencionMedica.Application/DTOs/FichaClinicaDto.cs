namespace AtencionMedica.Application.DTOs
{
    public class FichaClinicaDto
    {
        public int IdFichaClinica { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdPersonal { get; set; }
        public int IdEstadoFichaClinica { get; set; }
        public int IdModulo { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public bool EsActivo { get; set; }
    }
}

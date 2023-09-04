namespace AtencionMedica.Application.DTOs
{
    public class FichaClinicaGetDto
    {
        public int IdFichaClinica { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdPersonal { get; set; }
        public int IdEstadoFichaClinica { get; set; }
        public int IdModulo { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public bool EsActivo { get; set; }
        public virtual PacienteDto Paciente { get; set; }
        public virtual MedicoDto Medico { get; set; }
        public virtual PersonalDto? Personal { get; set; }
        public virtual EstadoFichaClinicaDto EstadoFichaClinica { get; set; }
        public virtual ModuloDto Modulo { get; set; }
    }
}

namespace AtencionMedica.Domain.Entities
{
    public class FichaClinica
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFichaClinica { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdPersonal { get; set; }
        public int IdEstadoFichaClinica { get; set; }
        public int IdModulo { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Personal? Personal { get; set; }
        public virtual EstadoFichaClinica EstadoFichaClinica { get; set; }
        public virtual Modulo Modulo{ get; set; }
    }
}

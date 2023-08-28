namespace AtencionMedica.Domain.Entities
{
    [Table("FichaClinica")]
    public class FichaClinica : BaseEntity
    {
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }
        [ForeignKey("IdPersonal")]
        public int? IdPersonal { get; set; }
        [ForeignKey("IdEstadoFichaClinica")]
        public int IdEstadoFichaClinica { get; set; }
        [ForeignKey("IdModulo")]
        public int IdModulo { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Personal? Personal { get; set; }
        public virtual EstadoFichaClinica EstadoFichaClinica { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<FichaClinicaDetalle> FichaClinicaDetalles { get; set; }
    }
}

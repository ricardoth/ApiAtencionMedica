namespace AtencionMedica.Domain.Entities
{
    public class FichaClinicaDetalle : BaseEntity
    {
        [ForeignKey("IdFichaClinica")]
        public int IdFichaClinica { get; set; }
        public bool AgudezaVisual { get; set; }
        public bool PresionIntraocular { get; set; }
        public bool FondoDeOjo { get; set; }
        public string? Observacion { get; set; }
        public virtual FichaClinica FichaClinica { get; set; }

    }
}

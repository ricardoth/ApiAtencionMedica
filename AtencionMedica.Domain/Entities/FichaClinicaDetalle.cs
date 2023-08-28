namespace AtencionMedica.Domain.Entities
{
    public class FichaClinicaDetalle : BaseEntity
    {
        [ForeignKey("IdFichaClinica")]
        public int IdFichaClinica { get; set; }
        public string? AgudezaVisual { get; set; }
        public string? PresionIntraocular { get; set; }
        public string? FondoDeOjo { get; set; }
        public string? Observacion { get; set; }
        public virtual FichaClinica FichaClinica { get; set; }

    }
}

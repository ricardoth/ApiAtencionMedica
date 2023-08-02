namespace AtencionMedica.Domain.Entities
{
    public class FichaClinicaDetalle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFichaClinicaDetalle { get; set; }
        [ForeignKey("IdFichaClinica")]
        public long IdFichaClinica { get; set; }
        public string? AgudezaVisual { get; set; }
        public string? PresionIntraocular { get; set; }
        public string? FondoDeOjo { get; set; }
        public string? Observacion { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public virtual FichaClinica FichaClinica { get; set; }

    }
}

namespace AtencionMedica.Application.DTOs
{
    public class FichaClinicaDetalleGetDto
    {
        public int IdFichaClinicaDetalle { get; set; }
        public int IdFichaClinica { get; set; }
        public bool AgudezaVisual { get; set; }
        public bool PresionIntraocular { get; set; }
        public bool FondoDeOjo { get; set; }
        public string? Observacion { get; set; }
        public bool EsActivo { get; set; }
        public virtual FichaClinicaDto FichaClinica { get; set; }
    }
}

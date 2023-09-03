namespace AtencionMedica.Application.Validators
{
    public class FichaClinicaDetalleValidator : AbstractValidator<FichaClinicaDetalle>
    {
        public FichaClinicaDetalleValidator()
        {
            RuleFor(e => e.IdFichaClinica).NotNull().WithMessage("El IdFichaClinica no puede ser núlo");
            RuleFor(e => e.IdFichaClinica).NotEmpty().WithMessage("El IdFichaClinica no puede estar vacío");
            RuleFor(e => e.IdFichaClinica).NotEqual(0).WithMessage("El IdFichaClinica no puede ser 0");

            RuleFor(e => e.AgudezaVisual).NotNull().WithMessage("El AgudezaVisual no puede ser núlo");
            RuleFor(e => e.AgudezaVisual).NotEmpty().WithMessage("El AgudezaVisual no puede estar vacío");

            RuleFor(e => e.PresionIntraocular).NotNull().WithMessage("El PresionIntraocular no puede ser núlo");
            RuleFor(e => e.PresionIntraocular).NotEmpty().WithMessage("El PresionIntraocular no puede estar vacío");

            RuleFor(e => e.FondoDeOjo).NotNull().WithMessage("El FondoDeOjo no puede ser núlo");
            RuleFor(e => e.FondoDeOjo).NotEmpty().WithMessage("El FondoDeOjo no puede estar vacío");

            RuleFor(e => e.Observacion).NotNull().WithMessage("La Observación no puede ser núlo");
            RuleFor(e => e.Observacion).NotEmpty().WithMessage("La Observación no puede estar vacío");
            RuleFor(e => e.Observacion).Length(3, 500).WithMessage("La Observación debe tener un mínimo de 3 y máximo 500 caractéres");
        }
    }
}

namespace AtencionMedica.Application.Validators
{
    public class FichaClinicaValidator : AbstractValidator<FichaClinica>
    {
        public FichaClinicaValidator()
        {
            RuleFor(e => e.IdPaciente).NotNull().WithMessage("El IdPaciente no puede ser núlo");
            RuleFor(e => e.IdPaciente).NotEmpty().WithMessage("El IdPaciente no puede estar vacío");
            RuleFor(e => e.IdPaciente).NotEqual(0).WithMessage("El IdPaciente no puede ser 0");

            RuleFor(e => e.IdMedico).NotNull().WithMessage("El IdMedico no puede ser núlo");
            RuleFor(e => e.IdMedico).NotEmpty().WithMessage("El IdMedico no puede estar vacío");
            RuleFor(e => e.IdMedico).NotEqual(0).WithMessage("El IdMedico no puede ser 0");

            RuleFor(e => e.IdPersonal).NotNull().WithMessage("El IdPersonal no puede ser núlo");
            RuleFor(e => e.IdPersonal).NotEmpty().WithMessage("El IdPersonal no puede estar vacío");
            RuleFor(e => e.IdPersonal).NotEqual(0).WithMessage("El IdPersonal no puede ser 0");
            
            RuleFor(e => e.IdEstadoFichaClinica).NotNull().WithMessage("El IdEstadoFichaClinica no puede ser núlo");
            RuleFor(e => e.IdEstadoFichaClinica).NotEmpty().WithMessage("El IdEstadoFichaClinica no puede estar vacío");
            RuleFor(e => e.IdEstadoFichaClinica).NotEqual(0).WithMessage("El IdEstadoFichaClinica no puede ser 0");

            RuleFor(e => e.IdModulo).NotNull().WithMessage("El IdModulo no puede ser núlo");
            RuleFor(e => e.IdModulo).NotEmpty().WithMessage("El IdModulo no puede estar vacío");
            RuleFor(e => e.IdModulo).NotEqual(0).WithMessage("El IdModulo no puede ser 0");

            RuleFor(e => e.FechaAtencion).NotNull().WithMessage("El FechaAtencion no puede ser núlo");
            RuleFor(e => e.FechaAtencion).NotEmpty().WithMessage("El FechaAtencion no puede estar vacío");

        }
    }
}

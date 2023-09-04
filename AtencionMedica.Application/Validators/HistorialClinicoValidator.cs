namespace AtencionMedica.Application.Validators
{
    public class HistorialClinicoValidator : AbstractValidator<HistorialClinico>
    {
        public HistorialClinicoValidator()
        {
            RuleFor(e => e.IdPaciente).NotNull().WithMessage("El IdPaciente no puede ser núlo");
            RuleFor(e => e.IdPaciente).NotEmpty().WithMessage("El IdPaciente no puede estar vacío");
            RuleFor(e => e.IdPaciente).NotEqual(0).WithMessage("El IdPaciente no puede ser 0");

            RuleFor(e => e.FechaHistorial).NotNull().WithMessage("FechaHistorial no puede ser núlo");
            RuleFor(e => e.FechaHistorial).NotEmpty().WithMessage("FechaHistorial no puede estar vacío"); 

            RuleFor(e => e.Diagnostico).NotNull().WithMessage("Diagnostico no puede ser núlo");
            RuleFor(e => e.Diagnostico).NotEmpty().WithMessage("Diagnostico no puede estar vacío");

            RuleFor(e => e.Nota).NotNull().WithMessage("Nota no puede ser núlo");
            RuleFor(e => e.Nota).NotEmpty().WithMessage("Nota no puede estar vacío");
        }
    }
}

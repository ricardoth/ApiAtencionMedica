namespace AtencionMedica.Application.Validators
{
    public class PatologiaPacienteValidator : AbstractValidator<PatologiaPaciente>
    {
        public PatologiaPacienteValidator()
        {
            RuleFor(e => e.IdPaciente).NotNull().WithMessage("El IdPaciente no puede ser núlo");
            RuleFor(e => e.IdPaciente).NotEmpty().WithMessage("El IdPaciente no puede estar vacío");
            RuleFor(e => e.IdPaciente).NotEqual(0).WithMessage("El IdPaciente no puede ser 0");

            RuleFor(e => e.IdPatologia).NotNull().WithMessage("El IdPatologia no puede ser núlo");
            RuleFor(e => e.IdPatologia).NotEmpty().WithMessage("El IdPatologia no puede estar vacío");
            RuleFor(e => e.IdPatologia).NotEqual(0).WithMessage("El IdPatologia no puede ser 0");

            RuleFor(e => e.FecComplicacion).NotNull().WithMessage("FecComplicacion no puede ser núlo");
            RuleFor(e => e.FecComplicacion).NotEmpty().WithMessage("FecComplicacion no puede estar vacío");
        }
    }
}

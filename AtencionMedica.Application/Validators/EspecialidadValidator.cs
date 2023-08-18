namespace AtencionMedica.Application.Validators
{
    public class EspecialidadValidator : AbstractValidator<Especialidad>
    {
        public EspecialidadValidator()
        {
            RuleFor(e => e.NombreEspecialidad)
                .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(e => e.NombreEspecialidad)
                .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(e => e.NombreEspecialidad)
                .Length(3, 100)
                .WithMessage("El nombre debe tener un mínimo de 3 y máximo de 150 caractéres");

        }
    }
}

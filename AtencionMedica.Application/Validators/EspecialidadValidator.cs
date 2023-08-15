namespace AtencionMedica.Application.Validators
{
    public class EspecialidadValidator : AbstractValidator<Especialidad>
    {
        public EspecialidadValidator()
        {
            RuleFor(especialidad => especialidad.NombreEspecialidad)
                .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(especialidad => especialidad.NombreEspecialidad)
                .Empty().WithMessage("El nombre no puede estar vacío");

            RuleFor(especialidad => especialidad.NombreEspecialidad)
                .Length(3, 100)
                .WithMessage("El nombre no puede estar vacío");

        }
    }
}

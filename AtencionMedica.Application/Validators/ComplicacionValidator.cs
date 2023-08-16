namespace AtencionMedica.Application.Validators
{
    public class ComplicacionValidator : AbstractValidator<Complicacion>
    {
        public ComplicacionValidator()
        {
            RuleFor(especialidad => especialidad.NombreComplicacion)
                .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(especialidad => especialidad.NombreComplicacion)
                .Length(3, 100)
                .WithMessage("El nombre no puede estar vacío");
        }
    }
}

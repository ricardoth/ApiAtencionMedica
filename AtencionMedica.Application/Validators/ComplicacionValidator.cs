namespace AtencionMedica.Application.Validators
{
    public class ComplicacionValidator : AbstractValidator<Complicacion>
    {
        public ComplicacionValidator()
        {
            RuleFor(e => e.NombreComplicacion)
                .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(e => e.NombreComplicacion)
               .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(e => e.NombreComplicacion)
                .Length(3, 100)
                .WithMessage("El nombre debe tener un mínimo de 3 y máximo de 150 caractéres");
        }
    }
}

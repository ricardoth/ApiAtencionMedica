namespace AtencionMedica.Application.Validators
{
    public class PatologiaValidator : AbstractValidator<Patologia>
    {
        public PatologiaValidator()
        {
            RuleFor(e => e.NombrePatologia)
            .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(e => e.NombrePatologia)
                .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(e => e.NombrePatologia)
                .Length(3, 150)
                .WithMessage("El nombre debe tener un mínimo de 3 y máximo de 150 caractéres");
        }
    }
}

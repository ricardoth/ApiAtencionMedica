namespace AtencionMedica.Application.Validators
{
    public class PatologiaValidator : AbstractValidator<Patologia>
    {
        public PatologiaValidator()
        {
            RuleFor(especialidad => especialidad.NombrePatologia)
            .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(especialidad => especialidad.NombrePatologia)
                .Length(3, 150)
                .WithMessage("El nombre no puede estar vacío");
        }
    }
}

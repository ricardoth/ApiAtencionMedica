namespace AtencionMedica.Application.Validators
{
    public class MedicamentoValidator : AbstractValidator<Medicamento>
    {
        public MedicamentoValidator()
        {
            RuleFor(e => e.NombreMedicamento)
               .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(e => e.NombreMedicamento)
               .NotEmpty().WithMessage("El nombre no puede estar vacío");

            RuleFor(e => e.NombreMedicamento)
                .Length(3, 150)
                .WithMessage("El nombre debe tener un mínimo de 3 y máximo de 150 caractéres");
        }
    }
}

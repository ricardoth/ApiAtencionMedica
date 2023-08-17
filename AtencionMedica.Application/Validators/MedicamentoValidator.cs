namespace AtencionMedica.Application.Validators
{
    public class MedicamentoValidator : AbstractValidator<Medicamento>
    {
        public MedicamentoValidator()
        {
            RuleFor(especialidad => especialidad.NombreMedicamento)
               .NotNull().WithMessage("El nombre no puede ser núlo");

            RuleFor(especialidad => especialidad.NombreMedicamento)
                .Length(3, 150)
                .WithMessage("El nombre no puede estar vacío");
        }
    }
}

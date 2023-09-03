namespace AtencionMedica.Application.Validators
{
    public class EspecialidadMedicoValidator : AbstractValidator<EspecialidadMedico>
    {
        public EspecialidadMedicoValidator()
        {
            RuleFor(e => e.IdMedico).NotNull().WithMessage("El IdMedico no puede ser núlo");
            RuleFor(e => e.IdMedico).NotEmpty().WithMessage("El IdMedico no puede estar vacío");
            RuleFor(e => e.IdMedico).NotEqual(0).WithMessage("El IdMedico no puede ser 0");

            RuleFor(e => e.IdEspecialidad).NotNull().WithMessage("El IdEspecialidad no puede ser núlo");
            RuleFor(e => e.IdEspecialidad).NotEmpty().WithMessage("El IdEspecialidad no puede estar vacío");
            RuleFor(e => e.IdEspecialidad).NotEqual(0).WithMessage("El IdEspecialidad no puede ser 0");

            RuleFor(e => e.CasaEstudio).NotNull().WithMessage("La CasaEstudio no puede ser núlo");
            RuleFor(e => e.CasaEstudio).NotEmpty().WithMessage("La CasaEstudio no puede estar vacío");
            RuleFor(e => e.CasaEstudio).Length(3, 200).WithMessage("La CasaEstudio debe tener un mínimo de 3 y máximo 200 caractéres");

            RuleFor(e => e.FechaObtencionEspecialidad).NotNull().WithMessage("La FechaObtencionEspecialidad no puede ser núlo");
            RuleFor(e => e.FechaObtencionEspecialidad).NotEmpty().WithMessage("La FechaObtencionEspecialidad no puede estar vacío");
        }
    }
}

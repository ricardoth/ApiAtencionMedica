namespace AtencionMedica.Application.Validators
{
    public class AgendaMedicoValidator : AbstractValidator<AgendaMedico>
    {
        public AgendaMedicoValidator()
        {
            RuleFor(e => e.IdMedico).NotNull().WithMessage("El IdMedico no puede ser núlo");
            RuleFor(e => e.IdMedico).NotEmpty().WithMessage("El IdMedico no puede estar vacío");
            RuleFor(e => e.IdMedico).NotEqual(0).WithMessage("El IdMedico no puede ser 0");

            RuleFor(e => e.IdEstadoAgendaMedico).NotNull().WithMessage("El IdEstadoAgendaMedico no puede ser núlo");
            RuleFor(e => e.IdEstadoAgendaMedico).NotEmpty().WithMessage("El IdEstadoAgendaMedico no puede estar vacío");
            RuleFor(e => e.IdEstadoAgendaMedico).NotEqual(0).WithMessage("El IdEstadoAgendaMedico no puede ser 0");

            RuleFor(e => e.FecInicio).NotNull().WithMessage("El FecInicio no puede ser núlo");
            RuleFor(e => e.FecInicio).NotEmpty().WithMessage("El FecInicio no puede estar vacío");

            RuleFor(e => e.FecFin).NotNull().WithMessage("La FecFin no puede ser núlo");
            RuleFor(e => e.FecFin).NotEmpty().WithMessage("La FecFin no puede estar vacío");

            RuleFor(e => e.HoraInicio).NotNull().WithMessage("La HoraInicio no puede ser núlo");
            RuleFor(e => e.HoraInicio).NotEmpty().WithMessage("La HoraInicio no puede estar vacío");

            RuleFor(e => e.HoraFin).NotNull().WithMessage("La HoraFin no puede ser núlo");
            RuleFor(e => e.HoraFin).NotEmpty().WithMessage("La HoraFin no puede estar vacío");
        }
    }
}

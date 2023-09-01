namespace AtencionMedica.Application.Validators
{
    public class RecetaMedicaValidator : AbstractValidator<RecetaMedica>
    {
        public RecetaMedicaValidator()
        {
            RuleFor(e => e.IdHistorialClinico).NotNull().WithMessage("El IdHistorialClinico no puede ser núlo");
            RuleFor(e => e.IdHistorialClinico).NotEmpty().WithMessage("El IdHistorialClinico no puede estar vacío");
            RuleFor(e => e.IdHistorialClinico).NotEqual(0).WithMessage("El IdHistorialClinico no puede ser 0");

            RuleFor(e => e.IdMedicamento).NotNull().WithMessage("El IdMedicamento no puede ser núlo");
            RuleFor(e => e.IdMedicamento).NotEmpty().WithMessage("El IdMedicamento no puede estar vacío");
            RuleFor(e => e.IdMedicamento).NotEqual(0).WithMessage("El IdMedicamento no puede ser 0");

            RuleFor(e => e.Instrucciones).NotNull().WithMessage("Las Instrucciones no puede ser núlo");
            RuleFor(e => e.Instrucciones).NotEmpty().WithMessage("Las Instrucciones no puede estar vacío");
            RuleFor(e => e.Instrucciones).Length(3, 500).WithMessage("Las Instrucciones debe tener un mínimo de 3 y máximo 500 caractéres");

            RuleFor(e => e.Cantidad).NotNull().WithMessage("La Cantidad no puede ser núlo");
            RuleFor(e => e.Cantidad).NotEmpty().WithMessage("La Cantidad no puede estar vacío");
            RuleFor(e => e.Cantidad).NotEqual(0).WithMessage("La Cantidad no puede ser 0");

            RuleFor(e => e.FecInicio).NotNull().WithMessage("La FecInicio no puede ser núlo");
            RuleFor(e => e.FecInicio).NotEmpty().WithMessage("La FecInicio no puede estar vacío");

            RuleFor(e => e.FecFin).NotNull().WithMessage("La FecFin no puede ser núlo");
            RuleFor(e => e.FecFin).NotEmpty().WithMessage("La FecFin no puede estar vacío");
        }
    }
}

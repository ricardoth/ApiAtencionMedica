namespace AtencionMedica.Application.Validators
{
    public class ModuloValidator : AbstractValidator<Modulo>
    {
        public ModuloValidator()
        {
            RuleFor(e => e.IdLugarAtencion).NotNull().WithMessage("El IdLugarAtencion no puede ser núlo");
            RuleFor(e => e.IdLugarAtencion).NotEmpty().WithMessage("El IdLugarAtencion no puede estar vacío");
            RuleFor(e => e.IdLugarAtencion).NotEqual(0).WithMessage("El IdLugarAtencion no puede ser 0");

            RuleFor(e => e.NombreModulo).NotNull().WithMessage("El NombreModulo no puede ser núlo");
            RuleFor(e => e.NombreModulo).NotEmpty().WithMessage("El NombreModulo no puede estar vacío");
            RuleFor(e => e.NombreModulo).Length(3, 100).WithMessage("El NombreModulo debe tener un mínimo de 3 y máximo de 150 caractéres");

            RuleFor(e => e.Descripcion).NotNull().WithMessage("La Descripcion no puede ser núlo");
            RuleFor(e => e.Descripcion).NotEmpty().WithMessage("La Descripcion no puede estar vacío");
            RuleFor(e => e.Descripcion).Length(3, 200).WithMessage("La Descripcion debe tener un mínimo de 3 y máximo de 150 caractéres");
        }
    }
}

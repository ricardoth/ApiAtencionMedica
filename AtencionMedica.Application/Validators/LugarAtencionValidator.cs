namespace AtencionMedica.Application.Validators
{
    public class LugarAtencionValidator : AbstractValidator<LugarAtencion>
    {
        public LugarAtencionValidator()
        {
            RuleFor(e => e.IdComuna).NotNull().WithMessage("El IdComuna no puede ser núlo");
            RuleFor(e => e.IdComuna).NotEmpty().WithMessage("El IdComuna no puede estar vacío");
            RuleFor(e => e.IdComuna).NotEqual(0).WithMessage("El IdComuna no puede ser 0");

            RuleFor(e => e.NombreLugar).NotNull().WithMessage("El NombreLugar no puede ser núlo");
            RuleFor(e => e.NombreLugar).NotEmpty().WithMessage("El NombreLugar no puede estar vacío");
            RuleFor(e => e.NombreLugar).Length(3, 100).WithMessage("El NombreLugar debe tener un mínimo de 3 y máximo de 100 caractéres");

            RuleFor(e => e.Direccion).NotNull().WithMessage("La Direccion no puede ser núlo");
            RuleFor(e => e.Direccion).NotEmpty().WithMessage("La Direccion no puede estar vacío");
            RuleFor(e => e.Direccion).Length(3, 200).WithMessage("La Direccion debe tener un mínimo de 3 y máximo de 200 caractéres");

            RuleFor(e => e.Fono).NotNull().WithMessage("La Descripcion no puede ser núlo");
            RuleFor(e => e.Fono).NotEmpty().WithMessage("La Descripcion no puede estar vacío");
            RuleFor(e => e.Fono).Length(3, 20).WithMessage("La Descripcion debe tener un mínimo de 3 y máximo de 20 caractéres");

            RuleFor(e => e.HorarioAtencion).NotNull().WithMessage("La Descripcion no puede ser núlo");
            RuleFor(e => e.HorarioAtencion).NotEmpty().WithMessage("La Descripcion no puede estar vacío");
            RuleFor(e => e.HorarioAtencion).Length(3, 30).WithMessage("La Descripcion debe tener un mínimo de 3 y máximo de 30 caractéres");
        }
    }
}

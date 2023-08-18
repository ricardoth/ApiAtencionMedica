namespace AtencionMedica.Application.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(e => e.Rut).NotNull().WithMessage("El Rut no puede ser núlo");
            RuleFor(e => e.Rut).NotEmpty().WithMessage("El Rut no puede estar vacío");
            RuleFor(e => e.Rut).NotEqual(0).WithMessage("El Rut no puede ser 0");

            RuleFor(e => e.Dv).NotNull().WithMessage("El Dv no puede ser núlo");
            RuleFor(e => e.Dv).NotEmpty().WithMessage("El Dv no puede ser vacío");
            RuleFor(e => e.Dv).Matches("^[0-9Kk]$").WithMessage("El Dv debe ser un número del 0 al 9 o la letra K");

            RuleFor(e => e.Nombres).NotNull().WithMessage("El nombre no puede ser núlo");
            RuleFor(e => e.Nombres).NotEmpty().WithMessage("El nombre no puede estar vacío");
            RuleFor(e => e.Nombres).Length(3, 200).WithMessage("El nombre debe tener un mínimo de 3 y máximo 200 caractéres");

            RuleFor(e => e.ApellidoPaterno).NotNull().WithMessage("El apellido paterno no puede ser núlo");
            RuleFor(e => e.ApellidoPaterno).NotEmpty().WithMessage("El nombre no puede estar vacío");
            RuleFor(e => e.ApellidoPaterno).Length(3, 200).WithMessage("El apellido paterno debe tener un mínimo de 3 y máximo 200 caractéres");

            RuleFor(e => e.FechaNacimiento).NotNull().WithMessage("La fecha de nacimento no puede ser núlo");
            RuleFor(e => e.FechaNacimiento).NotEmpty().WithMessage("La fecha de nacimento no puede ser vacío");

            RuleFor(e => e.Direccion).NotNull().WithMessage("La direccion no puede ser núlo");
            RuleFor(e => e.Direccion).NotEmpty().WithMessage("La direccion no puede estar vacío");
            RuleFor(e => e.Direccion).Length(3, 200).WithMessage("La direccion paterno debe tener un mínimo de 3 y máximo 200 caractéres");

            RuleFor(e => e.Telefono).NotNull().WithMessage("El teléfono no puede ser núlo");
            RuleFor(e => e.Telefono).NotEmpty().WithMessage("El teléfono no puede estar vacío");
            RuleFor(e => e.Telefono).Length(3, 20).WithMessage("El teléfono debe tener un mínimo de 3 y máximo 20 caractéres");

            RuleFor(e => e.Correo).NotNull().WithMessage("El correo no puede ser núlo");
            RuleFor(e => e.Correo).NotEmpty().WithMessage("El correo no puede estar vacío");
            RuleFor(e => e.Correo).Length(3, 200).WithMessage("El correo paterno debe tener un mínimo de 3 y máximo 200 caractéres");

            RuleFor(e => e.EstadoCivil).NotNull().WithMessage("El estado civil no puede ser núlo");
            RuleFor(e => e.EstadoCivil).NotEmpty().WithMessage("El estado civil no puede estar vacío");
            RuleFor(e => e.EstadoCivil).Length(3, 20).WithMessage("El estado civil debe tener un mínimo de 3 y máximo 20 caractéres");

            RuleFor(e => e.Sexo).NotNull().WithMessage("El sexo no puede ser núlo");
            RuleFor(e => e.Sexo).NotEmpty().WithMessage("El sexo no puede estar vacío");
            RuleFor(e => e.Sexo).Length(3, 20).WithMessage("El sexo debe tener un mínimo de 3 y máximo 20 caractéres");
        }
    }
}

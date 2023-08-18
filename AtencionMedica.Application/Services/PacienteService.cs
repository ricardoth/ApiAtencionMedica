namespace AtencionMedica.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Paciente> _validator;

        public PacienteService(IUnitOfWork unitOfWork, IValidator<Paciente> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public Task<ICollection<Paciente>> GetPacientes()
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Actualizar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task Agregar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

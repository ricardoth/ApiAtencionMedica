namespace AtencionMedica.Application.Services
{
    public class ComplicacionPacienteService : IComplicacionPacienteService
    {
        private readonly IComplicacionPacienteRepository _complicacionPacienteRepository;
        private readonly IValidator<ComplicacionPaciente> _validator;

        public ComplicacionPacienteService(IComplicacionPacienteRepository complicacionPacienteRepository, IValidator<ComplicacionPaciente> validator)
        {
            _complicacionPacienteRepository = complicacionPacienteRepository;   
            _validator = validator;
        }

        public async Task<ICollection<ComplicacionPaciente>> GetComplicacionesPacientes()
        {
            var result = await _complicacionPacienteRepository.GetComplicacionPacientes();
            if (result == null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public Task<ComplicacionPaciente> GetComplicacionPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Actualizar(Complicacion complicacionPaciente)
        {
            throw new NotImplementedException();
        }

        public Task Agregar(ComplicacionPaciente complicacionPaciente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

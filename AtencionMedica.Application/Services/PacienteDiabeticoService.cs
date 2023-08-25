namespace AtencionMedica.Application.Services
{
    public class PacienteDiabeticoService : IPacienteDiabeticoService
    {
        private readonly IPacienteDiabeticoRepository _pacienteDiabeticoRepository;

        public PacienteDiabeticoService(
            IPacienteDiabeticoRepository pacienteDiabeticoRepository)
        {
            _pacienteDiabeticoRepository = pacienteDiabeticoRepository;
        }

        public async Task<ICollection<PacienteDiabetico>> GetPacientesDiabeticos()
        {
            var result = await _pacienteDiabeticoRepository.GetAll();
            if (result is null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public async Task<PacienteDiabetico> GetPacienteDiabetico(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Actualizar(PacienteDiabetico medico)
        {
            throw new NotImplementedException();
        }

        public async Task Agregar(PacienteDiabetico medico)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

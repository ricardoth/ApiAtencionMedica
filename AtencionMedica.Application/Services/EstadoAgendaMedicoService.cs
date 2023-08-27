namespace AtencionMedica.Application.Services
{
    public class EstadoAgendaMedicoService : IEstadoAgendaMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoAgendaMedicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstadoAgendaMedico> GetEstadoAgendaMedico(int id)
        {
            var result = await _unitOfWork.EstadoAgendaMedicoRepository.GetById(id);

            if (result == null)
                throw new NotFoundException("No se encuentra el registro en la BD");

            return result;
        }

        public async Task<ICollection<EstadoAgendaMedico>> GetEstadoAgendasMedicos()
        {
            var result = await _unitOfWork.EstadoAgendaMedicoRepository.GetAll();

            if (result == null)
                throw new BadRequestException(ErrrorMessageStatus.NoRecordsFound);

            return result;
        }
    }
}

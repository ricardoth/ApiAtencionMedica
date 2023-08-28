namespace AtencionMedica.Application.Services
{
    public class EstadoFichaClinicaService : IEstadoFichaClinicaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoFichaClinicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstadoFichaClinica> GetEstadoFichaClinica(int id)
        {
            var result = await _unitOfWork.EstadoFichaClinicaRepository.GetById(id);

            if (result == null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task<ICollection<EstadoFichaClinica>> GetEstadoFichasClinicas()
        {
            var result = await _unitOfWork.EstadoFichaClinicaRepository.GetAll();

            if (result == null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }
    }
}

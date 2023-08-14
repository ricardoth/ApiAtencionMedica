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
            try
            {
                return await _unitOfWork.EstadoFichaClinicaRepository.GetById(id);  
            }
            catch (Exception ex)
            {
                throw new NotFoundException("No se encuentra el elemento en la BD");
            }
        }

        public async Task<ICollection<EstadoFichaClinica>> GetEstadoFichasClinicas()
        {
            try
            {
                return await _unitOfWork.EstadoFichaClinicaRepository.GetAll(); 
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo obtener los registros de la BD");
            }
        }
    }
}

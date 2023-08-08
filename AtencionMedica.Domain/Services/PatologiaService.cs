namespace AtencionMedica.Domain.Services
{
    public class PatologiaService : IPatologiaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatologiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Patologia>> GetPatologias()
        {
            try
            {
                var patologias = await _unitOfWork.PatologiaRepository.GetAll();
                return patologias;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en PatologiaService: {ex.Message}", ex);
            }
        }
    }
}

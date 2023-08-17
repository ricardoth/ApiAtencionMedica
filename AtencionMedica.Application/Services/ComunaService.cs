namespace AtencionMedica.Application.Services
{
    public class ComunaService : IComunaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComunaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comuna> GetComuna(int id)
        {
            var result = await _unitOfWork.ComunaRepository.GetById(id);

            if (result == null)
                throw new NotFoundException("No se encuentra el elemento en la BD");

            return result;
        }

        public async Task<ICollection<Comuna>> GetComunas()
        {
            var result = await _unitOfWork.ComunaRepository.GetAll();

            if (result == null)
                throw new BadRequestException("No se encuentran registros en la BD, no se pudo obtener la lista");

            return result;
        }
    }
}

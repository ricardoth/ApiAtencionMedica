namespace AtencionMedica.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaginationRepository<Paciente> _paginationRepository;
        private readonly IValidator<Paciente> _validator;
        private readonly PaginationOptions _paginationOptions;

        public PacienteService(IUnitOfWork unitOfWork,
            IPaginationRepository<Paciente> paginationRepository, 
            IValidator<Paciente> validator, 
            IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationRepository = paginationRepository;
            _validator = validator;
            _paginationOptions = paginationOptions.Value;
        }

        public async Task<PagedList<Paciente>> GetPacientes(PacienteQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            try
            {
                var totalCount = await _paginationRepository.GetAllTotalCount();
                var result = await _paginationRepository.GetAllPagination(filtros.PageNumber, filtros.PageSize);
                return PagedList<Paciente>.Create(result, filtros.PageNumber, filtros.PageSize, totalCount);
            }
            catch (Exception ex)
            {

                throw new BadRequestException("No se pudo obtener la lista de la Bd");
            }
        }

        public async Task<Paciente> GetPaciente(int id)
        {
            var result = await _unitOfWork.PacienteRepository.GetById(id);
            if (result is null)
                throw new NotFoundException("No se encuentra el registro en la BD");

            return result;
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

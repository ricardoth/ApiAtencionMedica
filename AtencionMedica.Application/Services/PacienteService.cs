using Microsoft.Extensions.Options;

namespace AtencionMedica.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPacientePaginationRepository _pacientePaginationRepository;
        private readonly IValidator<Paciente> _validator;
        private readonly PaginationOptions _paginationOptions;

        public PacienteService(IUnitOfWork unitOfWork, 
            IPacientePaginationRepository pacientePaginationRepository, 
            IValidator<Paciente> validator, 
            IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _pacientePaginationRepository = pacientePaginationRepository;
            _validator = validator;
            _paginationOptions = paginationOptions.Value;

        }

        public async Task<PagedList<Paciente>> GetPacientes(PacienteQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            var totalCount = await _pacientePaginationRepository.GetTotalPacientesCount();
            var result = await _pacientePaginationRepository.GetPacientesPagination(filtros.PageNumber, filtros.PageSize);

            return PagedList<Paciente>.Create(result, filtros.PageNumber, filtros.PageSize, totalCount);
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

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

        public async Task<bool> Actualizar(Paciente paciente)
        {
            var validationResult = _validator.Validate(paciente);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (paciente.Id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                var pacienteBd = await _unitOfWork.PacienteRepository.GetById(paciente.Id);
                pacienteBd.Rut = paciente.Rut;
                pacienteBd.Dv = paciente.Dv;
                pacienteBd.Nombres = paciente.Nombres;
                pacienteBd.ApellidoPaterno = paciente.ApellidoPaterno;
                pacienteBd.ApellidoMaterno = paciente.ApellidoMaterno;
                pacienteBd.Direccion = paciente.Direccion;
                pacienteBd.FechaNacimiento = paciente.FechaNacimiento;
                pacienteBd.Telefono = paciente.Telefono;
                pacienteBd.Correo = paciente.Correo;
                pacienteBd.EstadoCivil = paciente.EstadoCivil;
                pacienteBd.Sexo = paciente.Sexo;
                pacienteBd.EsActivo = paciente.EsActivo;
                pacienteBd.FecActualizacion = DateTime.Now;

                _unitOfWork.PacienteRepository.Update(pacienteBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo actualizar el registro");
            }
        }

        public async Task Agregar(Paciente paciente)
        {
            var validationResult = _validator.Validate(paciente);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.PacienteRepository.Add(paciente);
                await _unitOfWork.SaveChangesAsync();   
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo agregar el registro a la Bd");
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un número válido");

            try
            {
                await _unitOfWork.PatologiaRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo eliminar el registro de la Bd");
            }
        }
    }
}

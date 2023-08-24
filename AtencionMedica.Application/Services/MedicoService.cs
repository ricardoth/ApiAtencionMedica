namespace AtencionMedica.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaginationRepository<Medico> _paginationRepository;
        private readonly PaginationOptions _paginationOptions;
        private readonly IValidator<Medico> _validator;

        public MedicoService(IUnitOfWork unitOfWork,
            IPaginationRepository<Medico> paginationRepository,
            IOptions<PaginationOptions> paginationOptions,
            IValidator<Medico> validator)
        {
            _unitOfWork = unitOfWork;
            _paginationRepository = paginationRepository;
            _paginationOptions = paginationOptions.Value;
            _validator = validator;
        }

        public async Task<PagedList<Medico>> GetMedicos(MedicoQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            try
            {
                var totalCount = await _paginationRepository.GetAllTotalCount();
                var result = await _paginationRepository.GetAllPagination(filtros.PageNumber, filtros.PageSize);
                return PagedList<Medico>.Create(result, filtros.PageSize, filtros.PageNumber, totalCount);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo obtener la lista de la Bd");
            }
        }

        public async Task<Medico> GetMedico(int id)
        {
            var result = await _unitOfWork.MedicoRepository.GetById(id);

            if (result is null)
                throw new NotFoundException("No se encuentra el registro en la BD");

            return result;
        }

        public async Task<bool> Actualizar(Medico medico)
        {
            var validationResult = _validator.Validate(medico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (medico.Id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                var medicoBd = await _unitOfWork.MedicoRepository.GetById(medico.Id);
                medicoBd.Rut = medico.Rut;
                medicoBd.Dv = medico.Dv;
                medicoBd.Nombres = medico.Nombres;
                medicoBd.ApellidoPaterno = medico.ApellidoPaterno;
                medicoBd.ApellidoMaterno = medico.ApellidoMaterno;
                medicoBd.Telefono = medico.Telefono;
                medicoBd.Correo = medico.Correo;
                medicoBd.EsActivo = medico.EsActivo;

                _unitOfWork.MedicoRepository.Update(medicoBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo actualizar el registro");
            }
        }

        public async Task Agregar(Medico medico)
        {
            var validationResult = _validator.Validate(medico);
            if (!validationResult.IsValid) 
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.MedicoRepository.Add(medico);
                await _unitOfWork.SaveChangesAsync();   
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                await _unitOfWork.MedicoRepository.SoftDelete(id);
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

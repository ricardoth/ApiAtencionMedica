namespace AtencionMedica.Application.Services
{
    public class ModuloService : IModuloService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuloRepository _moduloRepository;
        private readonly IValidator<Modulo> _validator;

        public ModuloService(IUnitOfWork unitOfWork, IModuloRepository moduloRepository,IValidator<Modulo> validator)
        {
            _unitOfWork = unitOfWork;
            _moduloRepository = moduloRepository;
            _validator = validator;
        }
        public async Task<ICollection<Modulo>> GetModulos()
        {
            var result = await _moduloRepository.GetAll();

            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<Modulo> GetModulo(int id)
        {
            var result = await _moduloRepository.GetById(id);

            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task Agregar(Modulo modulo)
        {
            var validationResult = _validator.Validate(modulo);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.ModuloRepository.Add(modulo);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(Modulo modulo)
        {
            var validationResult = _validator.Validate(modulo);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (modulo.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var moduloBd = await _unitOfWork.ModuloRepository.GetById(modulo.Id);
                moduloBd.IdLugarAtencion = modulo.IdLugarAtencion;
                moduloBd.NombreModulo = modulo.NombreModulo;
                moduloBd.Descripcion = modulo.Descripcion;
                moduloBd.EsActivo = modulo.EsActivo;

                _unitOfWork.ModuloRepository.Update(moduloBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.UpdateFailed);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                await _unitOfWork.ModuloRepository.SoftDelete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.DeleteFailed);
            }
        }

    }
}

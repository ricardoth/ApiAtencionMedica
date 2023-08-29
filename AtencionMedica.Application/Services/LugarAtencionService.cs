namespace AtencionMedica.Application.Services
{
    public class LugarAtencionService : ILugarAtencionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILugarAtencionRepository _lugarAtencionRepository;
        private readonly IValidator<LugarAtencion> _validator;

        public LugarAtencionService(IUnitOfWork unitOfWork, ILugarAtencionRepository lugarAtencionRepository, IValidator<LugarAtencion> validator)
        {
            _unitOfWork = unitOfWork;
            _lugarAtencionRepository = lugarAtencionRepository;
            _validator = validator;
        }

        public async Task<ICollection<LugarAtencion>> GetLugaresAtenciones()
        {
            var result = await _lugarAtencionRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<LugarAtencion> GetLugarAtencion(int id)
        {
            var result = await _lugarAtencionRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task Agregar(LugarAtencion lugarAtencion)
        {
            var validationResult = _validator.Validate(lugarAtencion);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.LugarAtencionRepository.Add(lugarAtencion);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(LugarAtencion lugarAtencion)
        {
            var validationResult = _validator.Validate(lugarAtencion);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (lugarAtencion.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var lugarAtencionBd = await _unitOfWork.LugarAtencionRepository.GetById(lugarAtencion.Id);
                lugarAtencionBd.IdComuna = lugarAtencion.IdComuna;
                lugarAtencionBd.NombreLugar = lugarAtencion.NombreLugar;
                lugarAtencionBd.Direccion = lugarAtencion.Direccion;
                lugarAtencionBd.Fono = lugarAtencion.Fono;
                lugarAtencionBd.HorarioAtencion = lugarAtencion.HorarioAtencion;
                lugarAtencionBd.EsActivo = lugarAtencion.EsActivo;

                _unitOfWork.LugarAtencionRepository.Update(lugarAtencionBd);
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
                await _unitOfWork.LugarAtencionRepository.SoftDelete(id);
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

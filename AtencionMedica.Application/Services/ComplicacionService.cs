namespace AtencionMedica.Application.Services
{
    public class ComplicacionService : IComplicacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Complicacion> _validator;

        public ComplicacionService(IUnitOfWork unitOfWork, IValidator<Complicacion> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<Complicacion>> GetComplicaciones()
        {
            var result = await _unitOfWork.ComplicacionRepository.GetAll();

            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<Complicacion> GetComplicacion(int id)
        {
            var result = await _unitOfWork.ComplicacionRepository.GetById(id);

            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task Agregar(Complicacion complicacion)
        {
            var validationResult = _validator.Validate(complicacion);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.ComplicacionRepository.Add(complicacion);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(Complicacion complicacion)
        {
            var validationResult = _validator.Validate(complicacion);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (complicacion.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var complicacionBd = await _unitOfWork.ComplicacionRepository.GetById(complicacion.Id);
                complicacionBd.NombreComplicacion = complicacion.NombreComplicacion;
                complicacionBd.EsActivo = complicacion.EsActivo;

                _unitOfWork.ComplicacionRepository.Update(complicacionBd);
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
                await _unitOfWork.ComplicacionRepository.SoftDelete(id);
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

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

            if (result == null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public async Task<Complicacion> GetComplicacion(int id)
        {
            var result = await _unitOfWork.ComplicacionRepository.GetById(id);

            if (result == null)
                throw new NotFoundException("No existe la especialidad en la BD");

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
                throw new BadRequestException($"No se pudo crear el registro en la BD");
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
                throw new NotFoundException("Debe ingresar un Id válido");

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
                throw new BadRequestException($"No se pudo actualizar el registro de la BD");
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                await _unitOfWork.ComplicacionRepository.SoftDelete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo eliminar el registro de la BD");
            }
        }
    }
}

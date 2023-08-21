namespace AtencionMedica.Application.Services
{
    public class PatologiaService : IPatologiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Patologia> _validator;

        public PatologiaService(IUnitOfWork unitOfWork, IValidator<Patologia> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<Patologia>> GetPatologias()
        {
            var patologias = await _unitOfWork.PatologiaRepository.GetAll();
            
            if(patologias == null)
                throw new BadRequestException($"No se pudo obtener la lista de registros de la BD");

            return patologias;
        }

        public async Task<Patologia> GetPatologia(int id)
        {
            var patologia = await _unitOfWork.PatologiaRepository.GetById(id);

            if (patologia == null)
                throw new NotFoundException($"No se encuentra la patología en la BD");

            return patologia;
        }

        public async Task<bool> Actualizar(Patologia patologia)
        {
            var validationResult = _validator.Validate(patologia);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (patologia.Id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                var patologiaBd = await _unitOfWork.PatologiaRepository.GetById(patologia.Id);
                patologiaBd.NombrePatologia = patologia.NombrePatologia;
                patologiaBd.EsActivo = patologia.EsActivo;

                _unitOfWork.PatologiaRepository.Update(patologiaBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo actualizar el registro de la BD");
            }
        }

        public async Task Agregar(Patologia patologia)
        {
            var validationResult = _validator.Validate(patologia);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.PatologiaRepository.Add(patologia);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo crear el registro en la BD");
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                await _unitOfWork.PatologiaRepository.SoftDelete(id);
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

﻿namespace AtencionMedica.Application.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IValidator<Especialidad> _validator;   

        public EspecialidadService(IUnitOfWork unitOfWork, IValidator<Especialidad> validator)
        {
            _unitOfWork = unitOfWork;        
            _validator = validator;
        }

        public async Task<ICollection<Especialidad>> GetEspecialidades()
        {
            var result = await _unitOfWork.EspecialidadRepository.GetAll();

            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<Especialidad> GetEspecialidad(int id)
        {
            var result = await _unitOfWork.EspecialidadRepository.GetById(id);

            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task<bool> Actualizar(Especialidad especialidad)
        {
            var validationResult = _validator.Validate(especialidad);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (especialidad.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var especialidadBd = await _unitOfWork.EspecialidadRepository.GetById(especialidad.Id);
                especialidadBd.NombreEspecialidad = especialidad.NombreEspecialidad;
                especialidadBd.EsActivo = especialidad.EsActivo;

                _unitOfWork.EspecialidadRepository.Update(especialidadBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.UpdateFailed);
            }
        }

        public async Task Agregar(Especialidad especialidad)
        {
            var validationResult = _validator.Validate(especialidad);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.EspecialidadRepository.Add(especialidad);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                await _unitOfWork.EspecialidadRepository.SoftDelete(id);
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
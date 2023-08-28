using AtencionMedica.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AtencionMedica.Application.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Personal> _validator;

        public PersonalService(IUnitOfWork unitOfWork, IValidator<Personal> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<Personal>> GetPersonales()
        {
            var result = await _unitOfWork.PersonalRepository.GetAll();

            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<Personal> GetPersonal(int id)
        {
            var result = await _unitOfWork.PersonalRepository.GetById(id);

            if(result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task Agregar(Personal personal)
        {
            var validationResult = _validator.Validate(personal);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.PersonalRepository.Add(personal);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(Personal personal)
        {
            var validationResult = _validator.Validate(personal);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (personal.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var personalBd = await _unitOfWork.PersonalRepository.GetById(personal.Id);
                personalBd.Rut = personal.Rut;
                personalBd.Dv = personal.Dv;
                personalBd.Nombres = personal.Nombres;
                personalBd.ApellidoPaterno = personal.ApellidoPaterno;
                personalBd.ApellidoMaterno = personal.ApellidoMaterno;
                personalBd.Telefono = personal.Telefono;
                personalBd.Correo = personal.Correo;
                personalBd.EsActivo = personal.EsActivo;

                _unitOfWork.PersonalRepository.Update(personalBd);
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
                await _unitOfWork.PersonalRepository.SoftDelete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

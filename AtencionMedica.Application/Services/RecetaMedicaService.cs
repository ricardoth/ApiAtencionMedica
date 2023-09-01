using AtencionMedica.Domain.Entities;
using AtencionMedica.Domain.Interfaces;

namespace AtencionMedica.Application.Services
{
    public class RecetaMedicaService : IRecetaMedicaService
    {
        private readonly IRecetaMedicaRepository _recetaMedicaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<RecetaMedica> _validator;
        public RecetaMedicaService(IRecetaMedicaRepository recetaMedicaRepository, IUnitOfWork unitOfWork, IValidator<RecetaMedica> validator)
        {
            _recetaMedicaRepository = recetaMedicaRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<RecetaMedica>> GetRecetaMedicas()
        {
            var result = await _recetaMedicaRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<RecetaMedica> GetRecetaMedica(int id)
        {
            var result = await _recetaMedicaRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result; 
        }

        public async Task Agregar(RecetaMedica recetaMedica)
        {
            var validationResult = _validator.Validate(recetaMedica);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.RecetaMedicaRepository.Add(recetaMedica);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(RecetaMedica recetaMedica)
        {
            var validationResult = _validator.Validate(recetaMedica);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (recetaMedica.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var recetaMedicaBd = await _recetaMedicaRepository.GetById(recetaMedica.Id);
                recetaMedicaBd.IdMedicamento = recetaMedica.IdMedicamento;
                recetaMedicaBd.IdHistorialClinico = recetaMedica.IdHistorialClinico;
                recetaMedicaBd.Instrucciones = recetaMedica.Instrucciones;
                recetaMedicaBd.Cantidad = recetaMedica.Cantidad;
                recetaMedicaBd.Observacion = recetaMedica.Observacion;
                recetaMedicaBd.FecInicio = recetaMedica.FecInicio;
                recetaMedicaBd.FecFin = recetaMedica.FecFin;
                recetaMedicaBd.EsActivo = recetaMedica.EsActivo;

                _unitOfWork.RecetaMedicaRepository.Update(recetaMedicaBd);
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
                await _unitOfWork.RecetaMedicaRepository.SoftDelete(id);
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

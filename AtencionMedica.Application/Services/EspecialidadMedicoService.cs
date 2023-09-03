using AtencionMedica.Domain.Entities;
using AtencionMedica.Domain.Interfaces;

namespace AtencionMedica.Application.Services
{
    public class EspecialidadMedicoService : IEspecialidadMedicoService
    {
        private IEspecialidadMedicoRepository _especialidadMedicoRepository;
        private IUnitOfWork _unitOfWork;
        private IValidator<EspecialidadMedico> _validator;

        public EspecialidadMedicoService(IEspecialidadMedicoRepository especialidadMedicoRepository,
            IUnitOfWork unitOfWork,
            IValidator<EspecialidadMedico> validator)
        {
            _especialidadMedicoRepository = especialidadMedicoRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<EspecialidadMedico>> GetEspecialidadesMedicos()
        {
            var result = await _especialidadMedicoRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<EspecialidadMedico> GetEspecialidadMedico(int id)
        {
            var result = await _especialidadMedicoRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task Agregar(EspecialidadMedico especialidadMedico)
        {
            var validationResult = _validator.Validate(especialidadMedico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.EspecialidadMedicoRepository.Add(especialidadMedico);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(EspecialidadMedico especialidadMedico)
        {
            var validationResult = _validator.Validate(especialidadMedico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (especialidadMedico.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var especialidadMedicoBd = await _especialidadMedicoRepository.GetById(especialidadMedico.Id);
                especialidadMedicoBd.IdMedico = especialidadMedico.IdMedico;
                especialidadMedicoBd.IdEspecialidad = especialidadMedico.IdEspecialidad;
                especialidadMedicoBd.FechaObtencionEspecialidad = especialidadMedico.FechaObtencionEspecialidad;
                especialidadMedicoBd.CasaEstudio = especialidadMedico.CasaEstudio;
                especialidadMedicoBd.EsActivo = especialidadMedico.EsActivo;

                _unitOfWork.EspecialidadMedicoRepository.Update(especialidadMedicoBd);
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
                await _unitOfWork.EspecialidadMedicoRepository.SoftDelete(id);
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

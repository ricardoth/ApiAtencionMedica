namespace AtencionMedica.Application.Services
{
    public class HistorialClinicoService : IHistorialClinicoService
    {
        private readonly IHistorialClinicoRepository _historialClinicoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<HistorialClinico> _validator;

        public HistorialClinicoService(IHistorialClinicoRepository historialClinicoRepository,
            IUnitOfWork unitOfWork,
            IValidator<HistorialClinico> validator)
        {
            _historialClinicoRepository = historialClinicoRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<HistorialClinico>> GetHistorialesClinicos()
        {
            var result = await _historialClinicoRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<HistorialClinico> GetHistorialClinico(int id)
        {
            var result = await _historialClinicoRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task Agregar(HistorialClinico historialClinico)
        {
            var validationResult = _validator.Validate(historialClinico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.HistorialClinicoRepository.Add(historialClinico);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(HistorialClinico historialClinico)
        {
            var validationResult = _validator.Validate(historialClinico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (historialClinico.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var historialClinicoBd = await _historialClinicoRepository.GetById(historialClinico.Id);
                historialClinicoBd.IdPaciente = historialClinico.IdPaciente;
                historialClinicoBd.FechaHistorial = historialClinico.FechaHistorial;
                historialClinicoBd.Diagnostico = historialClinico.Diagnostico;
                historialClinicoBd.Nota = historialClinico.Nota;
                historialClinicoBd.EsActivo = historialClinico.EsActivo;

                _unitOfWork.HistorialClinicoRepository.Update(historialClinico);
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
                await _unitOfWork.HistorialClinicoRepository.SoftDelete(id);
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

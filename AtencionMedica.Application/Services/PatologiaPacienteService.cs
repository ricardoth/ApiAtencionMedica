namespace AtencionMedica.Application.Services
{
    public class PatologiaPacienteService : IPatologiaPacienteService
    {
        private readonly IPatologiaPacienteRepository _patologiaPacienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<PatologiaPaciente> _validator;

        public PatologiaPacienteService(IPatologiaPacienteRepository patologiaPacienteRepository,
            IUnitOfWork unitOfWork,
            IValidator<PatologiaPaciente> validator)
        {
            _patologiaPacienteRepository = patologiaPacienteRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<PatologiaPaciente>> GetPatologiasPacientes()
        {
            var result = await _patologiaPacienteRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<PatologiaPaciente> GetPatologiaPaciente(int id)
        {
            var result = await _patologiaPacienteRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task Agregar(PatologiaPaciente patologiaPaciente)
        {
            var validationResult = _validator.Validate(patologiaPaciente);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.PatologiaPacienteRepository.Add(patologiaPaciente);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(PatologiaPaciente patologiaPaciente)
        {
            var validationResult = _validator.Validate(patologiaPaciente);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (patologiaPaciente.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var patologiaPacienteBd = await _patologiaPacienteRepository.GetById(patologiaPaciente.Id);
                patologiaPacienteBd.IdPaciente = patologiaPaciente.IdPaciente;
                patologiaPacienteBd.IdPatologia = patologiaPaciente.IdPatologia;
                patologiaPacienteBd.FecComplicacion = patologiaPaciente.FecComplicacion;
                patologiaPacienteBd.EsActivo = patologiaPaciente.EsActivo;

                _unitOfWork.PatologiaPacienteRepository.Update(patologiaPacienteBd);
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
                await _unitOfWork.PatologiaPacienteRepository.SoftDelete(id);
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

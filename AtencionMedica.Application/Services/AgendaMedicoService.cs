namespace AtencionMedica.Application.Services
{
    public class AgendaMedicoService : IAgendaMedicoService
    {
        private readonly IAgendaMedicoRepository _agendaMedicoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AgendaMedico> _validator;

        public AgendaMedicoService(IAgendaMedicoRepository agendaMedicoRepository, IUnitOfWork unitOfWork
            ,IValidator<AgendaMedico> validator)
        {
            _agendaMedicoRepository = agendaMedicoRepository;
            _unitOfWork = unitOfWork;   
            _validator = validator;
        }

        public async Task<ICollection<AgendaMedico>> GetAgendasMedicos()
        {
            var result = await _agendaMedicoRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<AgendaMedico> GetAgendaMedico(int id)
        {
            var result = await _agendaMedicoRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }
        
        public async Task Agregar(AgendaMedico agendaMedico)
        {
            var validationResult = _validator.Validate(agendaMedico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.AgendaMedicoRepository.Add(agendaMedico);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(AgendaMedico agendaMedico)
        {
            var validationResult = _validator.Validate(agendaMedico);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (agendaMedico.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var agendaMedicoBd = await _agendaMedicoRepository.GetById(agendaMedico.Id);
                agendaMedicoBd.IdMedico = agendaMedico.IdMedico;
                agendaMedicoBd.IdEstadoAgendaMedico = agendaMedico.IdEstadoAgendaMedico;
                agendaMedicoBd.FecInicio = agendaMedico.FecInicio;
                agendaMedicoBd.FecFin = agendaMedico.FecFin;
                agendaMedicoBd.HoraInicio = agendaMedico.HoraInicio;
                agendaMedicoBd.HoraFin = agendaMedico.HoraFin;
                agendaMedicoBd.EsActivo = agendaMedico.EsActivo;

                _unitOfWork.AgendaMedicoRepository.Update(agendaMedicoBd);
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
                await _unitOfWork.AgendaMedicoRepository.SoftDelete(id);
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

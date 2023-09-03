namespace AtencionMedica.Application.Services
{
    public class FichaClinicaService : IFichaClinicaService
    {
        private readonly IFichaClinicaRepository _fichaClinicaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<FichaClinica> _validator;

        public FichaClinicaService(IFichaClinicaRepository fichaClinicaRepository,
            IUnitOfWork unitOfWork,
            IValidator<FichaClinica> validator)
        {
            _fichaClinicaRepository = fichaClinicaRepository;
            _unitOfWork = unitOfWork;
            _validator = validator; 
        }

        public async Task<FichaClinica> GetFichaClinica(int id)
        {
            var result = await _fichaClinicaRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task<ICollection<FichaClinica>> GetFichasClinicas()
        {
            var result = await _fichaClinicaRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task Agregar(FichaClinica fichaClinica)
        {
            var validationResult = _validator.Validate(fichaClinica);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.FichaClinicaRepository.Add(fichaClinica);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(FichaClinica fichaClinica)
        {
            var validationResult = _validator.Validate(fichaClinica);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (fichaClinica.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var fichaClinicaBd = await _fichaClinicaRepository.GetById(fichaClinica.Id);
                fichaClinicaBd.IdPaciente = fichaClinica.IdPaciente;
                fichaClinicaBd.IdMedico = fichaClinica.IdMedico;
                fichaClinicaBd.IdModulo = fichaClinica.IdModulo;
                fichaClinicaBd.IdEstadoFichaClinica = fichaClinica.IdEstadoFichaClinica;
                fichaClinicaBd.IdPersonal = fichaClinica.IdPersonal;
                fichaClinicaBd.FechaAtencion = fichaClinica.FechaAtencion;
                fichaClinicaBd.FechaAtencion = fichaClinica.FechaAtencion;
                fichaClinicaBd.EsActivo = fichaClinica.EsActivo;

                _unitOfWork.FichaClinicaRepository.Update(fichaClinicaBd);
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
                await _unitOfWork.FichaClinicaRepository.SoftDelete(id);
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

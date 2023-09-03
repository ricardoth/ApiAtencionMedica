namespace AtencionMedica.Application.Services
{
    public class FichaClinicaDetalleService : IFichaClinicaDetalleService
    {
        private readonly IFichaClinicaDetalleRepository _fichaClinicaDetalleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<FichaClinicaDetalle> _validator;

        public FichaClinicaDetalleService(IFichaClinicaDetalleRepository fichaClinicaDetalleRepository,
            IUnitOfWork unitOfWork,
            IValidator<FichaClinicaDetalle> validator)
        {
            _fichaClinicaDetalleRepository = fichaClinicaDetalleRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<FichaClinicaDetalle>> GetFichasClinicasDetalles()
        {
            var result = await _fichaClinicaDetalleRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<FichaClinicaDetalle> GetFichaClinicaDetalle(int id)
        {
            var result = await _fichaClinicaDetalleRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);
            return result;
        }

        public async Task<bool> Actualizar(FichaClinicaDetalle fichaClinicaDetalle)
        {
            var validationResult = _validator.Validate(fichaClinicaDetalle);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (fichaClinicaDetalle.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var fichaClinicaDetalleBd = await _fichaClinicaDetalleRepository.GetById(fichaClinicaDetalle.Id);
                fichaClinicaDetalleBd.IdFichaClinica = fichaClinicaDetalle.IdFichaClinica;
                fichaClinicaDetalleBd.FondoDeOjo = fichaClinicaDetalle.FondoDeOjo;
                fichaClinicaDetalleBd.AgudezaVisual = fichaClinicaDetalle.AgudezaVisual;
                fichaClinicaDetalleBd.PresionIntraocular = fichaClinicaDetalle.PresionIntraocular;
                fichaClinicaDetalleBd.Observacion = fichaClinicaDetalle.Observacion;
                fichaClinicaDetalleBd.EsActivo = fichaClinicaDetalle.EsActivo;

                _unitOfWork.FichaClinicaDetalleRepository.Update(fichaClinicaDetalleBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.UpdateFailed);
            }
        }

        public async Task Agregar(FichaClinicaDetalle fichaClinicaDetalle)
        {
            var validationResult = _validator.Validate(fichaClinicaDetalle);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.FichaClinicaDetalleRepository.Add(fichaClinicaDetalle);
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
                await _unitOfWork.FichaClinicaDetalleRepository.SoftDelete(id);
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

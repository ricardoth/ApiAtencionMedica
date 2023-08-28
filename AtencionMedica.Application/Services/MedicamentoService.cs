namespace AtencionMedica.Application.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Medicamento> _validator;

        public MedicamentoService(IUnitOfWork unitOfWork, IValidator<Medicamento> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ICollection<Medicamento>> GetMedicamentos()
        {
            var result =  await _unitOfWork.MedicamentoRepository.GetAll();
            if (result == null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);
            return result;
        }

        public async Task<Medicamento> GetMedicamento(int id)
        {
            var result = await _unitOfWork.MedicamentoRepository.GetById(id);
            if (result == null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }
       
        public async Task<bool> Actualizar(Medicamento medicamento)
        {
            var validationResult = _validator.Validate(medicamento);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            if (medicamento.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            try
            {
                var medicamentoBd = await _unitOfWork.MedicamentoRepository.GetById(medicamento.Id);
                medicamentoBd.NombreMedicamento = medicamento.NombreMedicamento;
                medicamentoBd.EsActivo = medicamento.EsActivo;

                _unitOfWork.MedicamentoRepository.Update(medicamentoBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.UpdateFailed);
            }
        }

        public async Task Agregar(Medicamento medicamento)
        {
            var validationResult = _validator.Validate(medicamento);
            if (!validationResult.IsValid)
            {
                var errores = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationResultException(errores);
            }

            try
            {
                await _unitOfWork.MedicamentoRepository.Add(medicamento);
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
                await _unitOfWork.MedicamentoRepository.SoftDelete(id);
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

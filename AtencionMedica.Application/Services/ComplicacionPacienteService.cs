namespace AtencionMedica.Application.Services
{
    public class ComplicacionPacienteService : IComplicacionPacienteService
    {
        private readonly IComplicacionPacienteRepository _complicacionPacienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ComplicacionPacienteService(IComplicacionPacienteRepository complicacionPacienteRepository, IUnitOfWork unitOfWork)
        {
            _complicacionPacienteRepository = complicacionPacienteRepository;   
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<ComplicacionPaciente>> GetComplicacionesPacientes()
        {
            var result = await _complicacionPacienteRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<ComplicacionPaciente> GetComplicacionPaciente(int id)
        {
            var result = await _complicacionPacienteRepository.GetById(id);

            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task Agregar(ComplicacionPaciente complicacionPaciente)
        {
            if (complicacionPaciente.IdPaciente <= 0)
                throw new BadRequestException("El IdPaciente no puede ser menor o igual a 0, por favor ingrese un Id válido");

            if (complicacionPaciente.IdComplicacion <= 0)
                throw new BadRequestException("El IdComplicacion no puede ser menor o igual a 0, por favor ingrese un Id válido");

            try
            {
                await _unitOfWork.ComplicacionPacienteRepository.Add(complicacionPaciente);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }

        public async Task<bool> Actualizar(ComplicacionPaciente complicacionPaciente)
        {
            if (complicacionPaciente.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);


            if (complicacionPaciente.IdPaciente <= 0)
                throw new BadRequestException("El IdPaciente no puede ser menor o igual a 0, por favor ingrese un Id válido");

            if (complicacionPaciente.IdComplicacion <= 0)
                throw new BadRequestException("El IdComplicacion no puede ser menor o igual a 0, por favor ingrese un Id válido");

            try
            {
                var complicacionPacienteBd = await _complicacionPacienteRepository.GetById(complicacionPaciente.Id);
                complicacionPacienteBd.IdComplicacion = complicacionPaciente.IdComplicacion;
                complicacionPacienteBd.IdPaciente = complicacionPaciente.IdPaciente;
                complicacionPacienteBd.FecComplicacion = complicacionPaciente.FecComplicacion;
                complicacionPacienteBd.EsActivo = complicacionPaciente.EsActivo;

                _unitOfWork.ComplicacionPacienteRepository.Update(complicacionPacienteBd);
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
                await _unitOfWork.ComplicacionPacienteRepository.SoftDelete(id);
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

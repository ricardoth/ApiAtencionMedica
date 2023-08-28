namespace AtencionMedica.Application.Services
{
    public class ComplicacionPacienteService : IComplicacionPacienteService
    {
        private readonly IComplicacionPacienteRepository _complicacionPacienteRepository;

        public ComplicacionPacienteService(IComplicacionPacienteRepository complicacionPacienteRepository)
        {
            _complicacionPacienteRepository = complicacionPacienteRepository;   
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
                await _complicacionPacienteRepository.Add(complicacionPaciente);
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

                await _complicacionPacienteRepository.Update(complicacionPacienteBd);
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
                await _complicacionPacienteRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.DeleteFailed);
            }
        }
    }
}

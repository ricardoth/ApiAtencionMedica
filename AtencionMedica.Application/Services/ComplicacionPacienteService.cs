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
            var result = await _complicacionPacienteRepository.GetComplicacionPacientes();
            if (result is null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public async Task<ComplicacionPaciente> GetComplicacionPaciente(int id)
        {
            var result = await _complicacionPacienteRepository.GetComplicacionPaciente(id);

            if (result is null)
                throw new NotFoundException("No se encuentra el registro en la BD");

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
                throw new BadRequestException($"No se pudo crear el registro en la BD");
            }
        }

        public async Task<bool> Actualizar(ComplicacionPaciente complicacionPaciente)
        {
            if (complicacionPaciente.Id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");


            if (complicacionPaciente.IdPaciente <= 0)
                throw new BadRequestException("El IdPaciente no puede ser menor o igual a 0, por favor ingrese un Id válido");

            if (complicacionPaciente.IdComplicacion <= 0)
                throw new BadRequestException("El IdComplicacion no puede ser menor o igual a 0, por favor ingrese un Id válido");

            try
            {
                var complicacionPacienteBd = await _complicacionPacienteRepository.GetComplicacionPaciente(complicacionPaciente.Id);
                complicacionPacienteBd.IdComplicacion = complicacionPaciente.IdComplicacion;
                complicacionPacienteBd.IdPaciente = complicacionPaciente.IdPaciente;
                complicacionPacienteBd.FecComplicacion = complicacionPaciente.FecComplicacion;
                complicacionPacienteBd.EsActivo = complicacionPaciente.EsActivo;

                await _complicacionPacienteRepository.Update(complicacionPacienteBd);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo actualizar el registro de la BD");
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                await _complicacionPacienteRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo eliminar el registro de la BD");
            }
        }
    }
}

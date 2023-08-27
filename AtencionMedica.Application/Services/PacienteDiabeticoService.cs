namespace AtencionMedica.Application.Services
{
    public class PacienteDiabeticoService : IPacienteDiabeticoService
    {
        private readonly IPacienteDiabeticoRepository _pacienteDiabeticoRepository;

        public PacienteDiabeticoService(
            IPacienteDiabeticoRepository pacienteDiabeticoRepository)
        {
            _pacienteDiabeticoRepository = pacienteDiabeticoRepository;
        }

        public async Task<ICollection<PacienteDiabetico>> GetPacientesDiabeticos()
        {
            var result = await _pacienteDiabeticoRepository.GetAll();
            if (result is null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public async Task<PacienteDiabetico> GetPacienteDiabetico(int id)
        {
            var result = await _pacienteDiabeticoRepository.GetById(id);
            if (result is null)
                throw new NotFoundException("No se encuentra el registro en la BD");

            return result;
        }

        public async Task Agregar(PacienteDiabetico pacienteDiabetico)
        {
            if (pacienteDiabetico.IdPaciente <= 0)
                throw new NotFoundException("Debe ingresar un IdPaciente válido");

            try
            {
                await _pacienteDiabeticoRepository.Add(pacienteDiabetico);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo agregar el registro a la BD");
            }

        }

        public async Task<bool> Actualizar(PacienteDiabetico pacienteDiabetico)
        {
            if (pacienteDiabetico.Id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            if (pacienteDiabetico.IdPaciente <= 0)
                throw new NotFoundException("Debe ingresar un IdPaciente válido");

            try
            {
                var pacienteDiabeticoBd = await _pacienteDiabeticoRepository.GetById(pacienteDiabetico.Id);
                pacienteDiabeticoBd.IdPaciente = pacienteDiabetico.IdPaciente;
                pacienteDiabeticoBd.FecEvaluacionDiabetes = pacienteDiabetico.FecEvaluacionDiabetes;
                pacienteDiabeticoBd.Neuropatia = pacienteDiabetico.Retinopatia;
                pacienteDiabeticoBd.FecNeuropatia = pacienteDiabetico.FecNeuropatia;
                pacienteDiabeticoBd.Retinopatia = pacienteDiabetico.Retinopatia;
                pacienteDiabeticoBd.FecRetinopatia = pacienteDiabetico.FecRetinopatia;
                pacienteDiabeticoBd.Amputacion = pacienteDiabetico.Retinopatia;
                pacienteDiabeticoBd.FecAmputacion = pacienteDiabetico.FecAmputacion;
                pacienteDiabeticoBd.EsActivo = pacienteDiabetico.EsActivo;

                await _pacienteDiabeticoRepository.Update(pacienteDiabeticoBd);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException("No se pudo actualizar el registro");
            }
        }
        

        public async Task<bool> Eliminar(int id)
        {
            if (id <= 0)
                throw new NotFoundException("Debe ingresar un Id válido");

            try
            {
                await _pacienteDiabeticoRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"No se pudo eliminar el registro de la BD");
            }
        }
    }
}

using AtencionMedica.Domain.Entities;
using AtencionMedica.Domain.Interfaces;

namespace AtencionMedica.Application.Services
{
    public class PacienteAdultoMayorService : IPacienteAdultoMayorService
    {
        private readonly IPacienteAdultoMayorRepository _pacienteAdultoMayorRepository;

        public PacienteAdultoMayorService(IPacienteAdultoMayorRepository pacienteAdultoMayorRepository)
        {
            _pacienteAdultoMayorRepository = pacienteAdultoMayorRepository;
        }

        public async Task<ICollection<PacienteAdultoMayor>> GetPacientesAdultosMayores()
        {
            var result = await _pacienteAdultoMayorRepository.GetAll();
            if (result is null)
                throw new BadRequestException(ErrorMessageStatus.NoRecordsFound);

            return result;
        }

        public async Task<PacienteAdultoMayor> GetPacienteAdultoMayor(int id)
        {
            var result = await _pacienteAdultoMayorRepository.GetById(id);
            if (result is null)
                throw new NotFoundException(ErrorMessageStatus.NotFound);

            return result;
        }

        public async Task Agregar(PacienteAdultoMayor pacienteAdultoMayor)
        {
            if (pacienteAdultoMayor.IdPaciente <= 0)
                throw new NotFoundException("Debe ingresar un IdPaciente válido");

            try
            {
                await _pacienteAdultoMayorRepository.Add(pacienteAdultoMayor);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.CreateFailed);
            }
        }
        public async Task<bool> Actualizar(PacienteAdultoMayor pacienteAdultoMayor)
        {
            if (pacienteAdultoMayor.Id <= 0)
                throw new NotFoundException(ErrorMessageStatus.NotValidId);

            if (pacienteAdultoMayor.IdPaciente <= 0)
                throw new NotFoundException("Debe ingresar un IdPaciente válido");

            try
            {
                var pacienteAdultoMayorBd = await _pacienteAdultoMayorRepository.GetById(pacienteAdultoMayor.Id);
                pacienteAdultoMayorBd.IdPaciente = pacienteAdultoMayor.IdPaciente;
                pacienteAdultoMayorBd.AutoValente = pacienteAdultoMayor.AutoValente;
                pacienteAdultoMayorBd.Dependencia = pacienteAdultoMayor.Dependencia;
                pacienteAdultoMayorBd.EsActivo = pacienteAdultoMayor.EsActivo;

                await _pacienteAdultoMayorRepository.Update(pacienteAdultoMayorBd);
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
                await _pacienteAdultoMayorRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ErrorMessageStatus.DeleteFailed);
            }
        }
    }
}

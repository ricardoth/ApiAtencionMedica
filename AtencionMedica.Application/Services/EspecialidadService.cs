using AtencionMedica.Domain.Entities;

namespace AtencionMedica.Application.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IUnitOfWork _unitOfWork;   

        public EspecialidadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;        
        }

        public async Task<ICollection<Especialidad>> GetEspecialidades()
        {
            try
            {
                return await _unitOfWork.EspecialidadRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en EspecialidadService: {ex.Message}", ex);
            }
        }

        public async Task<Especialidad> GetEspecialidad(int id)
        {
            try
            {
                return await _unitOfWork.EspecialidadRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en EspecialidadService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Actualizar(Especialidad especialidad)
        {
            try
            {
                var especialidadBd = await _unitOfWork.EspecialidadRepository.GetById(especialidad.Id);
                especialidadBd.NombreEspecialidad = especialidad.NombreEspecialidad;
                especialidadBd.EsActivo = especialidad.EsActivo;

                _unitOfWork.EspecialidadRepository.Update(especialidadBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en EspecialidadService: {ex.Message}", ex);
            }
        }

        public async Task Agregar(Especialidad especialidad)
        {
            try
            {
                await _unitOfWork.EspecialidadRepository.Add(especialidad);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en EspecialidadService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                await _unitOfWork.EspecialidadRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en EspecialidadService: {ex.Message}", ex);
            }
        }
    }
}

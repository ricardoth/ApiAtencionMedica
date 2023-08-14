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
            var result = await _unitOfWork.EspecialidadRepository.GetAll();

            if (result == null)
                throw new BadRequestException("No se pudo obtener la lista de la BD");

            return result;
        }

        public async Task<Especialidad> GetEspecialidad(int id)
        {
            var result = await _unitOfWork.EspecialidadRepository.GetById(id);

            if (result == null)
                throw new NotFoundException("No existe la especialidad en la BD");

            return result;
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
                throw new BadRequestException($"No se pudo actualizar el elemento");
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
                throw new Exception($"No se pudo crear el elemento");
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
                throw new BadRequestException($"No se pudo eliminar el elemento");
            }
        }
    }
}
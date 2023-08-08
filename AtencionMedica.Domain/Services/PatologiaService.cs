namespace AtencionMedica.Domain.Services
{
    public class PatologiaService : IPatologiaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatologiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ICollection<Patologia>> GetPatologias()
        {
            try
            {
                var patologias = await _unitOfWork.PatologiaRepository.GetAll();
                return patologias;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en PatologiaService: {ex.Message}", ex);
            }
        }
        public async Task<Patologia> GetPatologia(int id)
        {
            try
            {
                return await _unitOfWork.PatologiaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo obtener el elemento, Error en PatologiaService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Actualizar(Patologia patologia)
        {
            try
            {
                var patologiaBd = await _unitOfWork.PatologiaRepository.GetById(patologia.Id);
                patologiaBd.NombrePatologia = patologia.NombrePatologia;
                patologiaBd.EsActivo = patologia.EsActivo;

                _unitOfWork.PatologiaRepository.Update(patologiaBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo actualizar el elemento, Error en PatologiaService: {ex.Message}", ex);
            }
        }

        public async Task Agregar(Patologia patologia)
        {
            try
            {
                //Validar que no exista el registro
                await _unitOfWork.PatologiaRepository.Add(patologia);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo agregar el elemento, Error en PatologiaService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                await _unitOfWork.PatologiaRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo eliminar el elemento, Error en PatologiaService: {ex.Message}", ex);
            }
        }

    }
}

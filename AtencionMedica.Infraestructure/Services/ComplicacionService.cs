namespace AtencionMedica.Infraestructure.Services
{
    public class ComplicacionService : IComplicacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComplicacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Complicacion>> GetComplicaciones()
        {
            try
            {
                return await _unitOfWork.ComplicacionRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en ComplicacionService: {ex.Message}", ex);
            }
        }

        public async Task<Complicacion> GetComplicacion(int id)
        {
            try
            {
                return await _unitOfWork.ComplicacionRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en ComplicacionService: {ex.Message}", ex);
            }
        }

        public async Task Agregar(Complicacion complicacion)
        {
            try
            {
                await _unitOfWork.ComplicacionRepository.Add(complicacion);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en ComplicacionService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Actualizar(Complicacion complicacion)
        {
            try
            {
                var complicacionBd = await _unitOfWork.ComplicacionRepository.GetById(complicacion.Id);
                complicacionBd.NombreComplicacion = complicacion.NombreComplicacion;
                complicacionBd.EsActivo = complicacion.EsActivo;

                _unitOfWork.ComplicacionRepository.Update(complicacionBd);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en ComplicacionService: {ex.Message}", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                await _unitOfWork.ComplicacionRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();   
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error en ComplicacionService: {ex.Message}", ex);
            }
        }

    }
}

namespace AtencionMedica.Application.Interfaces
{
    public interface IComplicacionService
    {
        Task<ICollection<Complicacion>> GetComplicaciones();
        Task<Complicacion> GetComplicacion(int id);
        Task Agregar(Complicacion complicacion);
        Task<bool> Actualizar(Complicacion complicacion);
        Task<bool> Eliminar(int id);
    }
}

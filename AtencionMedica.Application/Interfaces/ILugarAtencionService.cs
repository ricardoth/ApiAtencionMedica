namespace AtencionMedica.Application.Interfaces
{
    public interface ILugarAtencionService
    {
        Task<ICollection<LugarAtencion>> GetLugaresAtenciones();
        Task<LugarAtencion> GetLugarAtencion(int id);
        Task Agregar(LugarAtencion lugarAtencion);
        Task<bool> Actualizar(LugarAtencion lugarAtencion);
        Task<bool> Eliminar(int id);
    }
}

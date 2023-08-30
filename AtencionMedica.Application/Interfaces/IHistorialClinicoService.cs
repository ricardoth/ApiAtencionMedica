namespace AtencionMedica.Application.Interfaces
{
    public interface IHistorialClinicoService
    {
        Task<ICollection<HistorialClinico>> GetHistorialesClinicos();
        Task<HistorialClinico> GetHistorialClinico(int id);
        Task Agregar(HistorialClinico historialClinico);
        Task<bool> Actualizar(HistorialClinico historialClinico);
        Task<bool> Eliminar(int id);
    }
}

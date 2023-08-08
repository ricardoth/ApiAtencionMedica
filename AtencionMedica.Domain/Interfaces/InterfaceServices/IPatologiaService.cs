namespace AtencionMedica.Domain.Interfaces.InterfaceServices
{
    public interface IPatologiaService
    {
        Task<ICollection<Patologia>> GetPatologias();
        Task<Patologia> GetPatologia(int id);
        Task Agregar(Patologia patologia);
        Task<bool> Actualizar(Patologia patologia);
        Task<bool> Eliminar(int id);
    }
}

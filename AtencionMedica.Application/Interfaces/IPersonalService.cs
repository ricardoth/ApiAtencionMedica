namespace AtencionMedica.Application.Interfaces
{
    public interface IPersonalService
    {
        Task<ICollection<Personal>> GetPersonales();
        Task<Personal> GetPersonal(int id);
        Task Agregar(Personal personal);
        Task<bool> Actualizar(Personal personal);
        Task<bool> Eliminar(int id);
    }
}

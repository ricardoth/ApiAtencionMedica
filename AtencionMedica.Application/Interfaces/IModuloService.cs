namespace AtencionMedica.Application.Interfaces
{
    public interface IModuloService
    {
        Task<ICollection<Modulo>> GetModulos();
        Task<Modulo> GetModulo(int id);
        Task Agregar(Modulo modulo);
        Task<bool> Actualizar(Modulo modulo);
        Task<bool> Eliminar(int id);
    }
}

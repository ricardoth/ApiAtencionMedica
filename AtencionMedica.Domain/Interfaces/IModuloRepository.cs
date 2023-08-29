namespace AtencionMedica.Domain.Interfaces
{
    public interface IModuloRepository
    {
        Task<ICollection<Modulo>> GetAll();
        Task<Modulo?> GetById(int id);
    }
}

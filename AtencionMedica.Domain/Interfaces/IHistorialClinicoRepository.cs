namespace AtencionMedica.Domain.Interfaces
{
    public interface IHistorialClinicoRepository
    {
        Task<ICollection<HistorialClinico>> GetAll();
        Task<HistorialClinico?> GetById(int id);
    }
}

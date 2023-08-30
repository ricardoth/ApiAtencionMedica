namespace AtencionMedica.Domain.Interfaces
{
    public interface IRecetaMedicaRepository
    {
        Task<ICollection<RecetaMedica>> GetAll();
        Task<RecetaMedica?> GetById(int id);
    }
}

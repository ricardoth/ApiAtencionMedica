namespace AtencionMedica.Domain.Interfaces
{
    public interface IPacienteDiabeticoRepository
    {
        Task<ICollection<PacienteDiabetico>> GetAll();
        Task<PacienteDiabetico?> GetById(int id);
        Task Add(PacienteDiabetico entity);
        Task Update(PacienteDiabetico entity);
        Task<bool> Delete(int id);
    }
}

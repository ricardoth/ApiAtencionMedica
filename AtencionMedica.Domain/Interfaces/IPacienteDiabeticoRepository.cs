namespace AtencionMedica.Domain.Interfaces
{
    public interface IPacienteDiabeticoRepository
    {
        Task<ICollection<PacienteDiabetico>> GetAll();
        Task<PacienteDiabetico?> GetById(int id);
    }
}

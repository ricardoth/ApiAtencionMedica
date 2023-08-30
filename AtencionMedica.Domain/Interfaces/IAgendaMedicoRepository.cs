namespace AtencionMedica.Domain.Interfaces
{
    public interface IAgendaMedicoRepository
    {
        Task<ICollection<AgendaMedico>> GetAll();
        Task<AgendaMedico?> GetById(int id);
    }
}

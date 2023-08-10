namespace AtencionMedica.Application.Interfaces
{
    public interface IEstadoAgendaMedicoService
    {
        Task<ICollection<EstadoAgendaMedico>> GetEstadoAgendasMedicos();
        Task<EstadoAgendaMedico> GetEstadoAgendaMedico(int id);
    }
}

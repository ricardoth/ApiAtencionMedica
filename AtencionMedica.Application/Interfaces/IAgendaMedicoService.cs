namespace AtencionMedica.Application.Interfaces
{
    public interface IAgendaMedicoService
    {
        Task<ICollection<AgendaMedico>> GetAgendasMedicos();
        Task<AgendaMedico> GetAgendaMedico(int id);
        Task Agregar(AgendaMedico agendaMedico);
        Task<bool> Actualizar(AgendaMedico agendaMedico);
        Task<bool> Eliminar(int id);
    }
}

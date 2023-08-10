namespace AtencionMedica.Application.Interfaces
{
    public interface IMedicoService
    {
        Task<ICollection<Medico>> GetMedicos();
        Task<Medico> GetMedico(int id);
        Task Agregar(Medico medico);
        Task<bool> Actualizar(Medico medico);
        Task<bool> Eliminar(int id);
    }
}

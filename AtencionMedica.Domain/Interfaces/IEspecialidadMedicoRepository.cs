namespace AtencionMedica.Domain.Interfaces
{
    public interface IEspecialidadMedicoRepository
    {
        Task<ICollection<EspecialidadMedico>> GetAll();
        Task<EspecialidadMedico?> GetById(int id);
    }
}

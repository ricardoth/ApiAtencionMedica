namespace AtencionMedica.Application.Interfaces
{
    public interface IEspecialidadMedicoService
    {
        Task<ICollection<EspecialidadMedico>> GetEspecialidadesMedicos();
        Task<EspecialidadMedico> GetEspecialidadMedico(int id);
        Task Agregar(EspecialidadMedico especialidadMedico);
        Task<bool> Actualizar(EspecialidadMedico especialidadMedico);
        Task<bool> Eliminar(int id);
    }
}

namespace AtencionMedica.Application.Interfaces
{
    public interface IEspecialidadService
    {
        Task<ICollection<Especialidad>> GetEspecialidades();
        Task<Especialidad> GetEspecialidad(int id);
        Task Agregar(Especialidad especialidad);
        Task<bool> Actualizar(Especialidad especialidad);
        Task<bool> Eliminar(int id);
    }
}

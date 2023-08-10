namespace AtencionMedica.Application.Interfaces
{
    public interface IPersonalService
    {
        Task<ICollection<Personal>> GetPacientes();
        Task<Personal> GetPaciente(int id);
        Task Agregar(Personal paciente);
        Task<bool> Actualizar(Personal paciente);
        Task<bool> Eliminar(int id);
    }
}

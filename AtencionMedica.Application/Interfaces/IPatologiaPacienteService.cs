namespace AtencionMedica.Application.Interfaces
{
    public interface IPatologiaPacienteService
    {
        Task<ICollection<PatologiaPaciente>> GetPatologiasPacientes();
        Task<PatologiaPaciente> GetPatologiaPaciente(int id);
        Task Agregar(PatologiaPaciente patologiaPaciente);
        Task<bool> Actualizar(PatologiaPaciente patologiaPaciente);
        Task<bool> Eliminar(int id);
    }
}

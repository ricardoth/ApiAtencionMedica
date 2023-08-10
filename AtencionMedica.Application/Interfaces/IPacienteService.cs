namespace AtencionMedica.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<ICollection<Paciente>> GetPacientes();
        Task<Paciente> GetPaciente(int id);
        Task Agregar(Paciente paciente);
        Task<bool> Actualizar(Paciente paciente);
        Task<bool> Eliminar(int id);
    }
}

namespace AtencionMedica.Application.Interfaces
{
    public interface IPacienteService 
    {
        Task<PagedList<Paciente>> GetPacientes(PacienteQueryFilter filtros);
        Task<Paciente> GetPaciente(int id);
        Task Agregar(Paciente paciente);
        Task<bool> Actualizar(Paciente paciente);
        Task<bool> Eliminar(int id);
    }
}
